using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ShoppingPromoCore.Core.Promotion;
using ShoppingPromoCore.Entities;
using ShoppingPromoCore.Interfaces;

namespace ShoppingPromoCore.Core.RuleFinder
{
    /// <summary>
    /// this gets the promotion entities configured.
    /// Should use a factory method to get promotion rule object from
    /// entity which will be used to apply promotion
    /// </summary>
    public class PromotionRuleFinder : IPromotionRuleFinder
    {
        private readonly IPromotionRuleRepo _promoRuleRepo;
        private readonly IPromotionFactory _promotionFactory;
        public PromotionRuleFinder(IPromotionRuleRepo promoRuleRepo,
            IPromotionFactory promotionFactory)
        {
            _promoRuleRepo = promoRuleRepo;
            _promotionFactory = promotionFactory;
        }

        public List<IPromotionRule> GetPromotionRules(Order order)
        {
            HashSet<char> neededIds = new HashSet<char>();
            foreach (var item in order.Items)
            {
                if (!neededIds.Contains(item.SkuId))
                {
                    neededIds.Add(item.SkuId);
                }
            }

            var configuredRuleDetails = _promoRuleRepo.GetPromotionRulesBySkuId(neededIds.ToList());
            List<IPromotionRule> rules = new List<IPromotionRule>();
            foreach (var ruleDetail in configuredRuleDetails)
            {
                rules.Add(_promotionFactory.GetPromotionRule(ruleDetail.PromoType));
            }
            return null;
        }
    }


    public interface IPromotionFactory
    {
        IPromotionRule GetPromotionRule(PromotionType promoType);
    }
    public class PromotionRuleFactory : IPromotionFactory
    {
        public IPromotionRule GetPromotionRule(PromotionType promoType)
        {
            IPromotionRule rule;
            switch (promoType)
            {
                case PromotionType.Fixed:
                    rule= new FixedPricePromotionRule();
                    break;
                case PromotionType.Percentage:
                    rule = new PercentagePricePromotionRule();
                    break;
                case PromotionType.Variable:
                    rule = new VariableDiscountPromotionRule();
                    break;
                default:
                    rule =  new FixedPricePromotionRule();
                    break;

            }

            return rule;

        }
    }
}
