using App.Data;
using App.Domain.Abstraction.Models;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Tools;
using App.Models.Command.Base;
using App.Models.Command.Common;
using App.Models.Dto.Base;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace App.Infrastructure.Handler
{
    /// <summary>
    /// Базовый класс, реализует интерфейс IStandartOperationHandler <inheritdoc cref="IStandartOperationHandler{TDto, TGetListCommand, TTabViewItemDto}"/>
    /// </summary>
    /// <typeparam name="TDto"></typeparam>
    /// <typeparam name="TGetListCommand"></typeparam>
    /// <typeparam name="TTabViewItemDto"></typeparam>
    public abstract class StandartOperationBaseHandler<TModel, TDto, TGetListCommand, TTabViewItemDto>
        : IStandartOperationHandler<TDto, TGetListCommand, TTabViewItemDto>
        where TModel : class, IIdentity<int>
        where TDto : BaseItemDto
        where TGetListCommand : BaseGetListCommand
    {
        #region CTOR
        /// <summary>
        /// <inheritdoc cref="AppDbContext"/>
        /// </summary>
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// <inheritdoc cref="AppAutoMapperConfig"/>
        /// </summary>
        private readonly IMapper _autoMapper;

        protected StandartOperationBaseHandler(AppDbContext dbContext, IMapper autoMapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        } 
        #endregion

        public virtual async Task ExecuteDelete(GetByIdCommand command)
        {
            var dbItem = await _dbContext.Set<TModel>().FindAsync(command.Id);
            _dbContext.Set<TModel>().Remove(dbItem);

            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TDto> ExecuteGetById(GetByIdCommand command)
        {
            var dbItem = await _dbContext.Set<TModel>().AsNoTracking().FirstOrDefaultAsync( x => x.Id == command.Id);
            return _autoMapper.Map<TDto>(dbItem);
        }

        public virtual async Task<BaseTabViewDto<TTabViewItemDto>> ExecuteGetList(TGetListCommand command)
        {
            var dbItem = await _dbContext.Set<TModel>().AsNoTracking()
                .Where(BuildFilterForGetListOperation(command))
                .ToArrayAsync();

            var recordCount = await _dbContext.Set<TModel>().AsNoTracking()
                .Where(BuildFilterForGetListOperation(command))
                .CountAsync();

            return new BaseTabViewDto<TTabViewItemDto>
            {
                RecordCount = recordCount,
                Items = _autoMapper.Map<TTabViewItemDto[]>(dbItem)
            };
        }

        /// <summary>
        /// Строит предикат для выполнения операции получения списка (ExecuteGetList)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected virtual Expression<Func<TModel, bool>> BuildFilterForGetListOperation(TGetListCommand command)
        {
            return x => true;
        }

        public virtual async Task<TDto> ExecuteSave(TDto dto)
        {
            var dbItem = await _dbContext.Set<TModel>()
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == dto.Id);
            if(dbItem == null)
            {
                dbItem = _autoMapper.Map<TModel>(dto);
                _dbContext.Set<TModel>().Add(dbItem);
            }
            else
            {
                dbItem = _autoMapper.Map<TModel>(dto);
                _dbContext.Set<TModel>().Update(dbItem);
            }

            await _dbContext.SaveChangesAsync();

            return await ExecuteGetById(new GetByIdCommand { Id = dbItem.Id });
        }
    }
}
