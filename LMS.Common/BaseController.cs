using AutoMapper;
using LMS.Common.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Common
{
    public class BaseController : ControllerBase
    {
        protected ISqlContext Context { get; }
        private IHttpContextAccessor _httpContextAccesor;
        private ILogicProxy _logic;

        public BaseController()
        {
            
        }

        public BaseController(ISqlContext context, BaseMapper mapper, IHttpContextAccessor httpContextAccessor, ILogicProxy logic):this()
        {
            string userEmail = string.Empty;
            Context = context;
            Mapper = mapper;
            _httpContextAccesor = httpContextAccessor;
            _logic = logic;
            mapper.Logic = this.Logic;

            if (_httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "useremail").SingleOrDefault() != null)
            {
                userEmail = httpContextAccessor.HttpContext.User.Claims.Where(x => x.Type == "useremail").SingleOrDefault().Value;
            }
            Thread.CurrentPrincipal = new LMSPrincipal(userEmail);
        }

        public BaseController(ISqlContext context, BaseMapper mapper)
        {
            Context = context;
            Mapper = mapper;
            mapper.Logic = this.Logic;
        }

        protected ILogicProxy Logic => _logic;

        #region Properties to get info from headers
        protected string CurrentToken
        {
            get
            {
                string ret = "";
                string tokenKey = "Authorization";

                if (Request.Headers.ContainsKey(tokenKey))
                {
                    ret = Request.Headers[tokenKey].ToString();
                    ret = ret.Replace("Bearer ", "");
                }

                return ret;
            }
        }

        [FromHeader(Name = "LANG")]
        public string CurrentLanguage { get; set; } = "ES";

        [FromHeader(Name = "CLIENT_DATETIME")]
        public string ClientDateStr { get; set; }

        public DateTime? ClientDate
        {
            get
            {
                try
                {
                    DateTime time = DateTime.ParseExact(ClientDateStr, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                    return time;
                }
                catch
                {
                    return null;
                }
            }
        }

        public BaseMapper Mapper
        {
            get;
        }
        #endregion

        #region Methods to map objects
        //protected T MapTo<T>(object item)
        //{
        //    return Mapper.MapTo<T>(item, CurrentLanguage);
        //}

        //protected IList<T> MapListTo<T>(object item)
        //{
        //    return Mapper.MapListTo<T>(item, CurrentLanguage);
        //}
        #endregion

        #region Methods to get current user info from token

        protected string GetCurrentUserEmail()
        {
            bool tokenExpires = false;
            return GetCurrentUserEmail(out tokenExpires);
        }
        protected int? GetCurrentCountryId()
        {
            bool tokenExpires = false;
            return GetCurrentCountryId(out tokenExpires);
        }

        protected string GetCurrentUserFullName()
        {
            bool tokenExpires = false;
            return GetCurrentUserFullName(out tokenExpires);
        }

        protected Guid? GetCurrentUserId()
        {
            bool tokenExpires = false;
            return GetCurrentUserId(out tokenExpires);
        }

        protected int? GetCurrentCountryId(out bool tokenExpires)
        {
            tokenExpires = false;
            var claim = _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "countryid").SingleOrDefault();

            if (claim == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string token = CurrentToken;
                tokenExpires = tokenHandler.CanReadToken(CurrentToken);
                return null;
            }

            return int.Parse(claim.Value);
        }

        protected string GetCurrentUserEmail(out bool tokenExpires)
        {
            tokenExpires = false;
            var claim = _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "useremail").SingleOrDefault();

            if (claim == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string token = CurrentToken;
                tokenExpires = tokenHandler.CanReadToken(CurrentToken);
                return string.Empty;
            }

            return claim.Value;
        }

        protected string GetCurrentUserFullName(out bool tokenExpires)
        {
            tokenExpires = false;
            var claim = _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "userfullname").SingleOrDefault();

            if (claim == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string token = CurrentToken;
                tokenExpires = tokenHandler.CanReadToken(CurrentToken);
                return string.Empty;
            }

            return claim.Value;
        }

        protected Guid? GetCurrentUserId(out bool tokenExpires)
        {
            tokenExpires = false;
            var claim = _httpContextAccesor.HttpContext.User.Claims.Where(x => x.Type == "userguid").SingleOrDefault();

            if (claim == null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                string token = CurrentToken;
                tokenExpires = tokenHandler.CanReadToken(CurrentToken);
                return null;
            }

            return Guid.Parse(claim.Value);
        }

        #endregion
    }
}
