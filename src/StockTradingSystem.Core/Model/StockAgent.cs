﻿using System;
using System.Collections.Generic;
using StockTradingSystem.Core.Access;
using StockTradingSystem.Core.Business;

namespace StockTradingSystem.Core.Model
{
    public class StockAgent
    {
        private readonly IUserAccess _userAccess;
        private readonly IBusiness _business;
        public User User { get; set; }

        public StockAgent(IUserAccess userAccess, IBusiness business, User user = null)
        {
            _userAccess = userAccess ?? throw new ArgumentNullException(nameof(userAccess));
            _business = business ?? throw new ArgumentNullException(nameof(business));
        }

        public bool User_create(string passwd, decimal cnyFree)
        {
            if (string.IsNullOrWhiteSpace(passwd))
            {
                throw new ArgumentException("密码不能为null、空或全是空格", nameof(passwd));
            }
            if (cnyFree < 0) throw new ArgumentOutOfRangeException(nameof(cnyFree), "初始账户余额应该大于等于零");
            if (User.Name == null) throw new ArgumentNullException(nameof(User.Name));

            return _userAccess.User_create(User.LoginName, passwd, User.Name, User.Type, cnyFree);
        }

        public bool User_login(string passwd)
        {
            CheckUserLogin(true);
            if (string.IsNullOrWhiteSpace(passwd))
            {
                throw new ArgumentException("密码不能为null、空或全是空格", nameof(passwd));
            }

            var res = _userAccess.User_login(User.LoginName, passwd, out var userId, out var name, out var type);
            if (!res) return false;
            User.UserId = userId ?? 0;
            User.Name = name ?? "";
            User.Type = type ?? -1;
            return true;
        }

        public bool User_repasswd(string oldPasswd, string newPasswd)
        {
            CheckUserLogin();
            if (string.IsNullOrWhiteSpace(oldPasswd))
            {
                throw new ArgumentException("密码不能为null、空或全是空格", nameof(oldPasswd));
            }

            if (string.IsNullOrWhiteSpace(newPasswd))
            {
                throw new ArgumentException("密码不能为null、空或全是空格", nameof(newPasswd));
            }

            return _userAccess.User_repasswd(User.UserId, oldPasswd, newPasswd);
        }

        public bool Cancel_Order(long orderId)
        {
            CheckUserLogin();
            return _business.Cancel_Order(User.UserId, orderId);
        }

        public bool Exec_Order(int stockId, int type, decimal price, int amount)
        {
            CheckUserLogin();
            return _business.Exec_Order(User.UserId, stockId, type, price, amount);
        }

        public List<StockDepthResult> Stock_depth(int stockId, int type)
        {
            CheckUserLogin();
            var res = _business.Stock_depth(stockId, type, out var stockDepthResult);
            return res ? stockDepthResult : null;
        }

        public UserCnyResult User_cny(long userId)
        {
            CheckUserLogin();
            var res = _business.User_cny(User.UserId, out var cnyFree, out var cnyFreezed, out var gpMoney);
            return res ? new UserCnyResult(cnyFree ?? 0, cnyFreezed ?? 0, gpMoney ?? 0) : null;
        }

        public List<UserOrderResult> User_order(long userId)
        {
            CheckUserLogin();
            var res = _business.User_order(User.UserId, out var userOrderResult);
            return res ? userOrderResult : null;
        }

        public List<UserStockResult> User_stock(long userId)
        {
            CheckUserLogin();
            var res = _business.User_stock(User.UserId, out var userStockResult);
            return res ? userStockResult : null;
        }

        /// <summary>
        /// 检查当前登录状态
        /// </summary>
        /// <param name="checkFlag">目标状态</param>
        private void CheckUserLogin(bool checkFlag = false)
        {
            if (User.IsLogin == checkFlag && checkFlag)
            {
                throw new Exception("用户已经登录，无法进行当前操作");
            }

            if (User.IsLogin == checkFlag && !checkFlag)
            {
                throw new Exception("用户尚未登录，无法进行当前操作");
            }
        }
    }
}