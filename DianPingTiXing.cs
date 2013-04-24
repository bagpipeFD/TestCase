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
    [Name("订单提醒")]
    public class DianPingTiXing : PlatFormBaseTestCase
    {

        [Test, Description("未提交订单提醒"), Category("我的携程2.0"), Author("周营")]
        [Name("订单提醒-未提交订单")]

        public void DianPingTiXingCase001()
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

                //验证未提交订单数
                Log.Info("验证未提交订单数");
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[1]/span")).Text, UserHT["未提交订单数"].ToString(), "验证未提交订单数");

                //验证未提交订单跳转
                Log.Info("验证未提交订单跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[1]")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.Contains(driver, driver.Url.ToString(), "orderstatus=4", "验证未提交订单跳转");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
        
        
        [Test, Description("未出行订单提醒"), Category("我的携程2.0"), Author("周营")]
        [Name("订单提醒-未出行订单")]

        public void DianPingTiXingCase002()
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

                //验证未出行订单数
                Log.Info("验证未出行订单数");
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[2]/span")).Text, UserHT["未出行订单数"].ToString(), "验证未出行订单数");

                //验证未出行订单跳转
                Log.Info("验证未出行订单跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[2]")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.Contains(driver, driver.Url.ToString(), "orderstatus=3", "验证未出行订单跳转");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }



        [Test, Description("待点评订单点评提醒"), Category("我的携程2.0"), Author("周营")]
        [Name("订单提醒-待点评订单")]

        public void DianPingTiXingCase003()
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

                Thread.Sleep(MaxSleepTime);

                //验证待点评订单数
                Log.Info("验证待点评订单数");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[3]")).Text, UserHT["待点评订单数"].ToString(), "验证待点评订单数");

                //验证待点评订单跳转
                Log.Info("验证待点评订单跳转");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[1]/div[1]/ul/li[4]/a[3]")).Click();
                Thread.Sleep(MaxSleepTime);
                CtripAssert.Contains(driver, driver.Url.ToString(), "orderstatus=15", "验证待点评订单跳转");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }


     


    }

    
}

