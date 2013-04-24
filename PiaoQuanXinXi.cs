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
    [Name("票券信息")]
    public class PiaoQuanXinXi : PlatFormBaseTestCase
    {

        [Test, Description("酒店消费券余额"), Category("我的携程2.0"), Author("周营")]
        [Name("票券信息-酒店消费券")]

        public void PiaoQuanXinXiCase001()
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

                //验证酒店消费卷余额
                Log.Info("验证酒店消费券余额");
                string Balance000 = driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[2]")).Text.ToString();
                CtripAssert.AreEqual(driver, Balance000, UserHT["酒店消费券余额"].ToString(), "验证酒店消费券余额");

                //验证酒店消费券链接跳转
                Log.Info("验证酒店消费券跳转");
              //driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[2]")).Click();
                driver.Navigate().GoToUrl("https://sinfo.testp.sh.ctriptravel.com/Balance/zh-cn/Coupon.aspx?type=tab");
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    
                }
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul[1]/li[1]")).Text, "消费券余额", "验证消费券跳转");
                //验证跳转后数据与跳转前相同
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul[1]/li[1]/span/em")).Text, Balance000, "验证消费券跳转余额");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

           
        [Test, Description("抵用券余额"), Category("我的携程2.0"), Author("周营")]
        [Name("票券信息-抵用券")]

        public void PiaoQuanXinXiCase002()
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

                Thread.Sleep(15000);

                //验证抵用券余额
                Log.Info("验证抵用券余额");
                string Balance001 = driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[3]")).Text.ToString();
                CtripAssert.AreEqual(driver, Balance001, UserHT["抵用券余额"].ToString(), "验证抵用券余额");

                //验证抵用券链接跳转
                Log.Info("验证抵用券跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[3]")).Click();
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    
                }
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul/li[1]")).Text, "可用金额", "验证抵用券跳转");
                //验证跳转后数据与跳转前相同
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul/li[1]/span[1]/em")).Text, Balance001, "验证抵用券跳转余额");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }


        [Test, Description("游票余额"), Category("我的携程2.0"), Author("周营")]
        [Name("票券信息-游票")]

        public void PiaoQuanXinXiCase003()
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

                Thread.Sleep(15000);

                //验证游票余额
                Log.Info("验证游票余额");
                string Balance002 = driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[4]")).Text.ToString();
                CtripAssert.AreEqual(driver, Balance002, UserHT["游票余额"].ToString(), "验证游票余额");

                //验证游票链接跳转
                Log.Info("验证游票跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[4]")).Click();
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();

                }
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/div[1]/ul/li[1]")).Text, "游票余额", "验证游票跳转");
                //验证跳转后数据与跳转前相同
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/div[1]/ul/li[1]/span/em")).Text, Balance002, "验证游票跳转余额");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
            
     /*   [Test, Description("现金账户余额"), Category("我的携程2.0"), Author("周营")]
        [Name("票券信息-现金账户")]

       public void PiaoQuanXinXiCase004()
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

                //验证未提交订单数
                Log.Info("验证现金账户余额");
                string Balance003 = driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[5]")).Text.ToString();
                CtripAssert.AreEqual(driver, Balance003,UserHT["现金账户余额"].ToString(), "验证现金账户余额");

                //验证未提交订单跳转
                Log.Info("验证现金账户跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[3]/a[5]")).Click();
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();

                }
                Thread.Sleep(5000);
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul[1]/li[1]")).Text, "现金余额", "验证现金账户跳转");
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/ul[1]/li[1]/span[1]/em")).Text, Balance003, "验证现金跳转余额");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }*/
      }
    
}




