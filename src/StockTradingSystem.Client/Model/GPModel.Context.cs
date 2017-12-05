﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace StockTradingSystem.Client.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GPEntities : DbContext
    {
        public GPEntities()
            : base("name=GPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<orders> orders { get; set; }
        public virtual DbSet<stocks> stocks { get; set; }
        public virtual DbSet<transactions> transactions { get; set; }
        public virtual DbSet<user_positions> user_positions { get; set; }
        public virtual DbSet<users> users { get; set; }
    
        public virtual int cancel_order(Nullable<long> user_id, Nullable<long> order_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            var order_idParameter = order_id.HasValue ?
                new ObjectParameter("order_id", order_id) :
                new ObjectParameter("order_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("cancel_order", user_idParameter, order_idParameter);
        }
    
        public virtual int exec_order(Nullable<long> user_id, Nullable<int> stock_id, Nullable<int> type, Nullable<decimal> price, Nullable<int> amount)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            var stock_idParameter = stock_id.HasValue ?
                new ObjectParameter("stock_id", stock_id) :
                new ObjectParameter("stock_id", typeof(int));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("price", price) :
                new ObjectParameter("price", typeof(decimal));
    
            var amountParameter = amount.HasValue ?
                new ObjectParameter("amount", amount) :
                new ObjectParameter("amount", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("exec_order", user_idParameter, stock_idParameter, typeParameter, priceParameter, amountParameter);
        }
    
        public virtual ObjectResult<stock_depth_Result> stock_depth(Nullable<int> stock_id, Nullable<int> type)
        {
            var stock_idParameter = stock_id.HasValue ?
                new ObjectParameter("stock_id", stock_id) :
                new ObjectParameter("stock_id", typeof(int));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<stock_depth_Result>("stock_depth", stock_idParameter, typeParameter);
        }
    
        public virtual int user_cny(Nullable<long> user_id, ObjectParameter cny_free, ObjectParameter cny_freezed, ObjectParameter gp_money)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("user_cny", user_idParameter, cny_free, cny_freezed, gp_money);
        }
    
        public virtual int user_create(string login_name, string passwd, string name, Nullable<int> type, Nullable<decimal> cny_free)
        {
            var login_nameParameter = login_name != null ?
                new ObjectParameter("login_name", login_name) :
                new ObjectParameter("login_name", typeof(string));
    
            var passwdParameter = passwd != null ?
                new ObjectParameter("passwd", passwd) :
                new ObjectParameter("passwd", typeof(string));
    
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var typeParameter = type.HasValue ?
                new ObjectParameter("type", type) :
                new ObjectParameter("type", typeof(int));
    
            var cny_freeParameter = cny_free.HasValue ?
                new ObjectParameter("cny_free", cny_free) :
                new ObjectParameter("cny_free", typeof(decimal));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("user_create", login_nameParameter, passwdParameter, nameParameter, typeParameter, cny_freeParameter);
        }
    
        public virtual int user_login(string login_name, string passwd, ObjectParameter user_id, ObjectParameter name, ObjectParameter type)
        {
            var login_nameParameter = login_name != null ?
                new ObjectParameter("login_name", login_name) :
                new ObjectParameter("login_name", typeof(string));
    
            var passwdParameter = passwd != null ?
                new ObjectParameter("passwd", passwd) :
                new ObjectParameter("passwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("user_login", login_nameParameter, passwdParameter, user_id, name, type);
        }
    
        public virtual ObjectResult<user_order_Result> user_order(Nullable<long> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user_order_Result>("user_order", user_idParameter);
        }
    
        public virtual int user_repasswd(Nullable<long> user_id, string old_passwd, string new_passwd)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            var old_passwdParameter = old_passwd != null ?
                new ObjectParameter("old_passwd", old_passwd) :
                new ObjectParameter("old_passwd", typeof(string));
    
            var new_passwdParameter = new_passwd != null ?
                new ObjectParameter("new_passwd", new_passwd) :
                new ObjectParameter("new_passwd", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("user_repasswd", user_idParameter, old_passwdParameter, new_passwdParameter);
        }
    
        public virtual ObjectResult<user_stock_Result> user_stock(Nullable<long> user_id)
        {
            var user_idParameter = user_id.HasValue ?
                new ObjectParameter("user_id", user_id) :
                new ObjectParameter("user_id", typeof(long));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<user_stock_Result>("user_stock", user_idParameter);
        }
    }
}