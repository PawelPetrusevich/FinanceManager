using System;
using AutoMapper;
using FinanceManager.Application.Common.Mapping;
using FinanceManager.Domain.DbModels;

namespace FinanceManager.Application.Common.Models
{
    public class TransactionVM : IMapFrom<TransactionDbModel>
    {
        public decimal? Value { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string SubCategory { get; set; }

        public string Currency { get; set; }

        public DateTime? Date { get; set; }

        public Guid? UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TransactionDbModel, TransactionVM>()
                .ForMember(d => d.Value, opt => opt.MapFrom((s => s.Value)))
                .ForMember(d => d.Category, opt => opt.MapFrom((s => s.Category.Name)))
                .ForMember(d => d.SubCategory, opt => opt.MapFrom((s => s.SubCategory.Name)))
                .ForMember(d => d.Currency, opt => opt.MapFrom((s => s.Account.Currency)))
                .ForMember(d => d.Description, opt => opt.MapFrom((s => s.Description)))
                .ForMember(d => d.Date, opt => opt.MapFrom((s => s.CreatedDate)));
        }
    }
}