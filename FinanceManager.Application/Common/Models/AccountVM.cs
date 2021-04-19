using AutoMapper;
using FinanceManager.Application.Common.Mapping;
using FinanceManager.Common.DbModels;

namespace FinanceManager.Application.Common.Models
{
    public class AccountVM : IMapFrom<AccountDbModel>
    {
        public string AccountId { get; set; }

        public string AcconuntName { get; set; }

        public decimal AccountSum { get; set; }

        public string Currency { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<AccountDbModel, AccountVM>()
                .ForMember(x => x.AcconuntName, opt => opt.MapFrom(y => y.AccountName))
                .ForMember(x => x.AccountId, opt => opt.MapFrom(y => y.Id.ToString()))
                .ForMember(x => x.AccountSum, opt => opt.MapFrom(x => x.AccauntSum));
        }
    }
}