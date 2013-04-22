using System;
using System.Collections.Generic;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Services
{
    public class ParametersBuilder
    {
        private readonly Dictionary<string, object> _parameters;

        public ParametersBuilder()
        {
            _parameters = new Dictionary<string, object>();
        }

        public ParametersBuilder PageNumber(int number)
        {
            if (!_parameters.ContainsKey(Constants.PAGE))
            {
                _parameters.Add(Constants.PAGE, number);
            }
            else
            {
                _parameters[Constants.PAGE] = number;
            }
            return this;
        }

        public ParametersBuilder ItemsPerPage(int count)
        {
            if (!_parameters.ContainsKey(Constants.PAGE_SIZE))
            {
                _parameters.Add(Constants.PAGE_SIZE, count);
            }
            else
            {
                _parameters[Constants.PAGE_SIZE] = count;
            }
            return this;
        }

        public ParametersBuilder UpdatedAfter(DateTime dateTime)
        {
            if (!_parameters.ContainsKey(Constants.UPDATED_AFTER))
            {
                _parameters.Add(Constants.UPDATED_AFTER, dateTime.ToUniversalTime());
            }
            else
            {
                _parameters[Constants.UPDATED_AFTER] = dateTime.ToUniversalTime();
            }
            return this;
        }

        public Dictionary<string, object> Build()
        {
            return _parameters;
        }
    }
}
