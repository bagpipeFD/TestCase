using System;
using MbUnit.Framework;
using Gallio.Framework;
using Ctrip.Automation.Framework.Base;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using Ctrip.Automation.Framework.Selenium;
using Ctrip.Automation.Framework.Lib;
using Ctrip.Automation.Framework.Attribute;
using Ctrip.Automation.MyCtrip2.Business;
using System.Reflection;
using System.Threading;

namespace Ctrip.Automation.MyCtrip2._0.TestCase
{

    [TestFixture]
    [Name("订单查询")]
    public class DianPingChaXun : PlatFormBaseTestCase
    {

        [Test, Description("国内酒店查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-国内酒店查询")]

        public void DianPingChaXunCase001()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());
                Thread.Sleep(MIDSleepTime);
                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_HotelOrder")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("选择国内酒店");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("ddl_orderRange")), "国内酒店");
                Log.Info("返回订单查询结果");
                driver.FindElement(By.Id("btn_search")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面正确
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "酒店订单", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
        [Test, Description("海外酒店查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-海外酒店查询")]

        public void DianPingChaXunCase002()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_HotelOrder")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("选择海外酒店");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("ddl_orderRange")), "海外酒店");
                Log.Info("返回订单查询结果");
                driver.FindElement(By.Id("btn_search")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面正确
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "酒店订单", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("国内机票查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-国内机票查询")]

        public void DianPingChaXunCase003()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_FltOrder")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("选择国内机票");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("ddl_scope")), "国内机票");
                Log.Info("返回订单查询结果");
                driver.FindElement(By.Id("btn_search")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[7]/div[5]/div[2]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面正确
                //CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "机票订单", "验证跳转页面");              
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("国际机票查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-国际机票查询")]

        public void DianPingChaXunCase004()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_FltOrder")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("选择国际机票");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("ddl_scope")), "国际机票");
                Log.Info("返回订单查询结果");
                driver.FindElement(By.Id("btn_search")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[7]/div[5]/div[2]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面正确
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "机票订单", "验证跳转页面");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("机+酒订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-机+酒订单查询")]

        public void DianPingChaXunCase005()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_FltHtlOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[7]/div[3]/div[2]/div/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MaxSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "携程机酒", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("旅游度假订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-旅游度假订单查询")]

        public void DianPingChaXunCase006()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_PkgOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[2]/div/table/tbody/tr/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MaxSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "旅游度假订单", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }



        [Test, Description("高铁订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-高铁订单查询")]

        public void DianPingChaXunCase007()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_RailwayOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[7]/div[3]/div[2]/div/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "高铁订单", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("美食订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-美食订单查询")]

        public void DianPingChaXunCase008()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_DiningOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[2]/div[1]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MaxSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//div[4]/div/div[1]/a[1]")).Text, "找餐厅", "验证跳转页面");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("团购订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-团购订单查询")]

        public void DianPingChaXunCase009()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_TeamOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[2]/div[1]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MaxSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("hotel_detail_info")).Text, "团购信息", "验证跳转页面");
            
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("游票订单查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-游票订单查询")]

        public void DianPingChaXunCase010()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MIDSleepTime);

                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_TicketOrder")).Click();
                Thread.Sleep(MIDSleepTime);
                Log.Info("等待订单查询结果");
                Log.Info("点击具体订单");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[2]/div/table/tbody/tr/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MaxSleepTime);
                //验证跳转页面
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("od_state")).Text, "礼品卡订单详情", "验证跳转页面");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("惠选酒店查询"), Category("我的携程2.0"), Author("周营")]
        [Name("订单查询-惠选酒店查询")]

        public void DianPingChaXunCase011()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());
                Thread.Sleep(MIDSleepTime);
                //订单页面跳转
                Log.Info("订单页面跳转");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_HotelOrder")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("选择惠选酒店");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("ddl_orderRange")), "惠选酒店");
                Log.Info("返回订单查询结果");
                driver.FindElement(By.Id("btn_search")).Click();
                Thread.Sleep(MinSleepTime);
                Log.Info("点击具体订单");
                /*driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/table/tbody/tr[1]/td[2]")).Click();
                Bcom.SwitchPage(driver);
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转页面正确
                CtripAssert.Contains(driver, driver.FindElement(By.ClassName("mem_location")).Text, "酒店订单", "验证跳转页面");
            
                 */ }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }


     





    }


}

