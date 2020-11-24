using App.Data;
using App.Domain.Entity.JW;
using App.Infrastructure.Interfaces;
using App.Infrastructure.Tools;
using App.Models.Command.Base;
using App.Models.Command.Common;
using App.Models.Dto.Base;
using App.Models.Dto.JW;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace App.Infrastructure.Handler.Sample
{
    public class BaseStandartOperationHandler
        : IStandartOperationHandler<CourthouseTypeDto, BaseGetListCommand, BaseTabViewDto<CourthouseTypeTabItemDto>, CourthouseTypeTabItemDto>
    {
        #region CTOR
        /// <summary>
        /// <inheritdoc cref="AppDbContext"/>
        /// </summary>
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// <inheritdoc cref="AutoMapperConfig"/>
        /// </summary>
        private readonly AppAutoMapperConfig _autoMapper;

        public BaseStandartOperationHandler(AppDbContext dbContext, AppAutoMapperConfig autoMapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _autoMapper = autoMapper ?? throw new ArgumentNullException(nameof(autoMapper));
        } 
        #endregion

        public async Task ExecuteDelete(GetByIdCommand command)
        {
            var dbData = await _dbContext.Set<CourthouseType>().FindAsync(command.Id);
            _dbContext.Set<CourthouseType>().Remove(dbData);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CourthouseTypeDto> ExecuteGetById(GetByIdCommand command)
        {
            var dbData = await _dbContext.Set<CourthouseType>().FindAsync(command.Id);
            return _autoMapper.Mapper.Map<CourthouseTypeDto>(dbData);
        }

        public async Task<BaseTabViewDto<CourthouseTypeTabItemDto>> ExecuteGetList(BaseGetListCommand command)
        {
            var dbData = await _dbContext.Set<CourthouseType>().ToArrayAsync();
            var recordCount = await _dbContext.Set<CourthouseType>().CountAsync();

            return new BaseTabViewDto<CourthouseTypeTabItemDto>
            {
                RecordCount = recordCount,
                Items = _autoMapper.Mapper.Map<CourthouseTypeTabItemDto[]>(dbData)
            };
        }

        public async Task<CourthouseTypeDto> ExecuteSave(CourthouseTypeDto dto)
        {
            
            var dbdata = await _dbContext.Set<CourthouseType>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == dto.Id);
            if(dbdata == null)
            {
                dbdata = _autoMapper.Mapper.Map<CourthouseType>(dto);
                _dbContext.Set<CourthouseType>().Add(dbdata);
            }
            else
            {
                dbdata = _autoMapper.Mapper.Map<CourthouseType>(dto);
            }
            await _dbContext.SaveChangesAsync();

            return await ExecuteGetById(new GetByIdCommand { Id = dbdata.Id });
        }
    }
}
