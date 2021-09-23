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
                var ruleInfo = _promotionFactory.GetPromotionRule(ruleDetail.PromoType);
                ruleInfo.Id = ruleDetail.Id;
                ruleInfo.Name = ruleDetail.Name;
                ruleInfo.PromotionRuleItems = new List<PromotionRuleItem>();
                foreach (var promoRuleItemDetails in ruleDetail.PromotionRuleDetails)
                {
                    ruleInfo.PromotionRuleItems.Add(new PromotionRuleItem{ Quantity = promoRuleItemDetails.Quantity,
                        SkuId = promoRuleItemDetails.SkuId});
                }
                rules.Add(ruleInfo);
            }
            return rules;
        }
    }
}
