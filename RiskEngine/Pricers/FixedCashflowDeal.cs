﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RiskEngine.Framework;
using RiskEngine.Factors;
using VectorAccelerator;

namespace RiskEngine.Pricers
{
    public enum Currency { EUR, USD }
    
    public class FixedCashflowDeal : Deal
    {
        public double Amount { get; set; }

        public Currency Currency { get; set; }

        public DateTime PaymentDate { get; set; }
    }

    public class FixedCashflowPricer : Pricer<FixedCashflowDeal>
    {
        DiscountFactorNonCash _df;

        public FixedCashflowPricer(FixedCashflowDeal deal)
        {
            _deal = deal;
        }

        public void Register(SimulationGraph graph)
        {
            _df = graph.RegisterFactor<DiscountFactorNonCash>(_deal.Currency.ToString());
        }

        public void Price(int timeIndex, out NArray pv)
        {
            pv = _deal.Amount * _df[timeIndex, _deal.PaymentDate];
        }
    }
}