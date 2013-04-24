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
    [Name("订单管理")]
    public class DianDanGuanLi : PlatFormBaseTestCase
    {

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理菜单验证")]

        public void DingDanGuanLiCase001()
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

                Thread.Sleep(5000);

                //验证订单管理菜单展开，其他菜单收起
                Log.Info("验证订单管理菜单展开");
                Boolean flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_ALLOrder"));
                CtripAssert.AreEqual(driver, flag.ToString(), "True", "我的订单菜单已展开");
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyAccount"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "个人中心菜单未展开");
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_Passenger"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "常用信息管理菜单未展开");
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyAccount"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "应用中心菜单未展开");
                //点击其他菜单，收起订单管理菜单
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[2]/dt/span")).Click();
                //验证订单管理菜单已收起
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_ALLOrder"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "我的订单菜单已收起");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理全部订单链接验证")]

        public void DingDanGuanLiCase002()
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

                Thread.Sleep(5000);

                //验证订单管理全部订单链接存在并点击
                Log.Info("验证订单管理全部订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[1]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的订单", "验证跳转链接是否正确");
                //设置时间区间显示订单数
                TestLog.WriteLine("验证不同时间区间订单显示");
                TestLog.WriteLine("检查已完成订单");
                TestLog.WriteLine("检查最近一个月已完成订单数");
                String notendtext = driver.FindElement(By.Id("h3_contianerF")).Text;
                int flagA = int.Parse(notendtext.Substring(notendtext.IndexOf('(') + 1, notendtext.IndexOf(')') - notendtext.IndexOf('(') - 1));
                CtripAssert.IsTrue(driver, flagA >= 0);
                TestLog.WriteLine("检查最近三个月已完成订单数");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("sel_orderrange")), "最近3个月订单");
                Thread.Sleep(MIDSleepTime);
                int flagB = int.Parse(notendtext.Substring(notendtext.IndexOf('(') + 1, notendtext.IndexOf(')') - notendtext.IndexOf('(') - 1));
                CtripAssert.IsTrue(driver, flagB >= flagA);
                TestLog.WriteLine("检查最近一年已完成订单数");
                SeleniumFun.SelectByText(driver.FindElement(By.Id("sel_orderrange")), "最近1年订单");
                Thread.Sleep(MIDSleepTime);
                int flagC = int.Parse(notendtext.Substring(notendtext.IndexOf('(') + 1, notendtext.IndexOf(')') - notendtext.IndexOf('(') - 1));
                CtripAssert.IsTrue(driver, flagC >= flagA);
                
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理机票订单链接验证")]

        public void DingDanGuanLiCase003()
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

                Thread.Sleep(5000);

                //验证订单管理订单链接存在并点击
                Log.Info("验证订单管理机票订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[2]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[7]/div[3]/div[1]/h3")).Text, "待完成的机票订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理酒店订单链接验证")]

        public void DingDanGuanLiCase004()
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

                Thread.Sleep(5000);

                //验证订单管理酒店订单链接存在并点击
                Log.Info("验证订单管理酒店订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[3]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的酒店订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理旅游度假订单链接验证")]

        public void DingDanGuanLiCase005()
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

                Thread.Sleep(5000);

                //验证旅游度假菜单链接存在并点击
                Log.Info("验证订单管理旅游度假订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[4]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的旅游度假订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理机酒订单链接验证")]

        public void DingDanGuanLiCase006()
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

                Thread.Sleep(5000);

                //验证订单管理机酒菜单链接存在并点击
                Log.Info("验证订单管理机酒订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[5]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[7]/div[3]/div[1]/h3")).Text, "待完成的机+酒订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理团购订单链接验证")]

        public void DingDanGuanLiCase007()
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

                Thread.Sleep(5000);

                //验证订单团购菜单链接存在并点击
                Log.Info("验证订单管理团购订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[6]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的团购订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理铁保行订单链接验证")]

        public void DingDanGuanLiCase008()
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

                Thread.Sleep(5000);

                //验证订单铁保行菜单链接存在并点击
                Log.Info("验证订单管理铁保行订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[7]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[7]/div[3]/div[1]/h3")).Text, "待完成的铁保行订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理美食订单链接验证")]

        public void DingDanGuanLiCase009()
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

                Thread.Sleep(5000);

                //验证订单美食订单菜单链接存在并点击
                Log.Info("验证订单管理美食订单链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[1]/dd[8]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的美食订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("订单管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("订单管理-订单管理游票订单链接验证")]

        public void DingDanGuanLiCase010()
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

                Thread.Sleep(5000);

                //验证订单管理游票菜单链接存在并点击
                Log.Info("验证订单管理游票订单链接");
                driver.FindElement(By.XPath("html/body/form/ul/li/div[2]/dl[1]/dd[9]/a")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/h3")).Text, "待完成的礼品卡订单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

    }
 
}
        