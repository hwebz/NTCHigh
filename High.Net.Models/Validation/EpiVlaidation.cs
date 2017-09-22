using System;
using EPiServer.Core;
using System.ComponentModel.DataAnnotations;
namespace High.Net.Validation
{
    //Chandrakant Mane Date:10-01-2017
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MaxItemCount : ValidationAttribute
    {
        private readonly int _limit;
        public int Limit
        {
            get { return _limit; }
        }

        public MaxItemCount(int limit)
        {
            _limit = limit;
        }

        public override bool IsValid(object value)
        {
            return ValidateContentArea(value as ContentArea);
        }

        private bool ValidateContentArea(ContentArea contentArea)
        {
            if (contentArea == null || contentArea.Items == null)
                return true;

            return contentArea.Items.Count <= Limit;
        }

        public override string FormatErrorMessage(string name)
        {
            return "Maximum "+name+" Count should be " + _limit;
        }
    }

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public sealed class MinItemCount : ValidationAttribute
    {
        private readonly int _limit;
        public int Limit
        {
            get { return _limit; }
        }

        public MinItemCount(int limit)
        {
            _limit = limit;
        }

        public override bool IsValid(object value)
        {
            return ValidateContentArea(value as ContentArea);
        }

        private bool ValidateContentArea(ContentArea contentArea)
        {
            if (contentArea == null || contentArea.Items == null)
                return true;

            return !(contentArea.Items.Count < Limit);
        }

        public override string FormatErrorMessage(string name)
        {
            return "Minimum "+name+" Count should be " + _limit;
        }
    }
}