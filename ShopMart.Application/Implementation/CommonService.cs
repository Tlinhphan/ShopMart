using AutoMapper;
using AutoMapper.QueryableExtensions;
using ShopMart.Application.Interfaces;
using ShopMart.Application.ViewModels.Blog;
using ShopMart.Application.ViewModels.Common;
using ShopMart.Data.Entities;
using ShopMart.Data.IRepositores;
using ShopMart.Infrastructure.Interfaces;
using ShopMart.Utilities.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopMart.Application.Implementation
{
    public class CommonService : ICommonService
    {
        IFooterRepository _footerRepository;
        ISystemConfigRepository _systemConfigRepository;
        IUnitOfWork _unitOfWork;
        ISlideRepository _slideRepository;
        public CommonService(IFooterRepository footerRepository,
            ISystemConfigRepository systemConfigRepository,
            IUnitOfWork unitOfWork,
            ISlideRepository slideRepository)
        {
            _footerRepository = footerRepository;
            _unitOfWork = unitOfWork;
            _systemConfigRepository = systemConfigRepository;
            _slideRepository = slideRepository;
        }

        public FooterViewModel GetFooter()
        {
            var data = _footerRepository
                                .FindSingle(x => x.Id == CommonConstants.DefaultFooterId);

            var result = Mapper.Map<Footer, FooterViewModel>(data);

            var footerVm = new FooterViewModel()
            {
                Id=data.Id,
                Content=data.Content
            };

            return result;
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository.FindAll(x => x.Status && x.GroupAlias == groupAlias)
                                    .ProjectTo<SlideViewModel>().ToList();
        }

        public SystemConfigViewModel GetSystem(string code)
        {
            throw new NotImplementedException();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            var data = _systemConfigRepository.FindSingle(x => x.Id == code);

            return Mapper.Map<SystemConfig, SystemConfigViewModel>(data);
        }
    }
}
