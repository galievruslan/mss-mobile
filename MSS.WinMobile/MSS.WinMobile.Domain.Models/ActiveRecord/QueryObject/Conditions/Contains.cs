﻿using System;

namespace MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions
{
    public class Between : Condition
    {
        private readonly string _queryCondition;

        public Between(DateTime from, DateTime to)
        {
            _queryCondition = string.Format(" BETWEEN '{0}' AND '{1}'", from, to);
        }

        public override string ToString()
        {
            return _queryCondition;
        }
    }
}
