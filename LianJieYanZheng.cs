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
using OpenQA.Selenium.Interactions;

namespace Ctrip.Automation.MyCtrip2._0.TestCase
{

    [TestFixture]
    [Name("链接验证")]
    public class LianJieYanZheng : PlatFormBaseTestCase
    {

        [Test, Description("应用中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("应用中心菜单验证")]

        public void LianJieYanZhengCase001()
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

                Thread.Sleep(MinSleepTime);

                //验证应用中心菜单收起
                Log.Info("验证应用中心菜单默认收起");
                Boolean flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_FlightTool"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "应用中心菜单默认收起");
                //验证应用中心菜单展开
                Log.Info("验证应用中心菜单展开");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[4]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_FlightTool"));
                CtripAssert.AreEqual(driver, flag.ToString(), "True", "应用中心菜单已展开");
            }

            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("机票工具箱"), Category("我的携程2.0"), Author("周营")]
        [Name("宣传推广-机票工具箱")]

        public void LianJieYanZhengCase002()
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

                Thread.Sleep(MinSleepTime);

                //验证机票工具箱模块
                Log.Info("验证机票工具箱模块");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[1]/dl")).Text, "机票工具箱", "验证模块完整");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[1]/dl")).Text, "低价订阅提醒", "验证链接一存在");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[1]/dl")).Text, "航班实时起降信息", "验证链接二存在");
                //验证链接跳转
                /*Log.Info("验证链接跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[1]")).Click();
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.Url.ToString(), "orderstatus=4", "验证未提交订单跳转");
            
                 */
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("会员互动"), Category("我的携程2.0"), Author("周营")]
        [Name("宣传推广-会员互动")]

        public void LianJieYanZhengCase003()
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

                Thread.Sleep(MinSleepTime);

                //验证会员互动模块
                Log.Info("验证会员互动模块");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/dl")).Text, "会员互动", "验证模块完整");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/dl")).Text, "携程贵宾俱乐部", "验证链接一存在");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/dl")).Text, "积分奖励活动专区", "验证链接二存在");
                //验证链接跳转
                /*Log.Info("验证链接跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[1]")).Click();
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.Url.ToString(), "orderstatus=4", "验证未提交订单跳转");
            
                 */
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("应用中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("应用中心-携程快讯链接验证")]
        public void LianJieYanZhengCase004()
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

                Thread.Sleep(MinSleepTime);

                //验证携程快讯链接存在并点击
                Log.Info("应用中心携程快讯链接验证");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[4]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_CtripNews")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/div[2]/div[1]/strong")).Text, "携程快讯", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("应用中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("应用中心-电子账单链接验证")]
        public void LianJieYanZhengCase005()
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

                Thread.Sleep(MinSleepTime);

                //验证电子账单链接存在并点击
                Log.Info("应用中心电子账单链接验证");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[4]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_ElectBill")).Click();
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[2]/div[1]/strong")).Text, "电子账单", "验证跳转链接是否正确");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("应用中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("应用中心-旅游分享链接验证")]
        public void LianJieYanZhengCase006()
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

                Thread.Sleep(MinSleepTime);

                //验证旅游分享链接存在并点击
                Log.Info("应用中心旅游分享链接验证");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[4]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_TripShare")).Click();
                Bcom.SwitchPage(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.Url.ToString(), "http://travel.testp.sh.ctriptravel.com/uid-aM00018803-kongjian", "验证链接跳转");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("特卖汇验证"), Category("我的携程2.0"), Author("周营")]
        [Name("特卖汇链接验证")]
        public void LianJieYanZhengCase007()
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

                Thread.Sleep(MinSleepTime);

                //打开悬浮菜单
                Log.Info("打开更多悬浮菜单");
                IWebElement ele = driver.FindElement(By.Id("a_moreLink"));
                
                new Actions(driver).MoveToElement(ele).Perform();

                driver.FindElement(By.LinkText("特卖汇")).Click();
                Thread.Sleep(MIDSleepTime);
                //验证跳转链接正确
                CtripAssert.AreEqual(driver, driver.FindElement(By.ClassName("pkg")).Text,"特卖机票", "验证链接跳转");


            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
    }
}
    


       