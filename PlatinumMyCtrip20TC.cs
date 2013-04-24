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



namespace Ctrip.Automation.MyCtrip2
{
    [TestFixture]
    [Name("会员等级-白金会员")]
    public class PlatinumMyCtrip20TC : PlatFormBaseTestCase
    {

        [Test, Description("中文白金用户登录验证"), Category("我的携程2.0"), Author("刘慧")]
        [Name("中文登录-白金用户")]

        public void MemberLoginCase001()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver, LogWrite);
                loginOn.CNLoginOn(UserHT["白金登录名"].ToString(), UserHT["白金密码"].ToString());

                //验证用户登录名
                Log.Info("验证用户登录名");
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//li[@id='base_bd']/div[3]/div/div/ul/li/a")).Text, UserHT["白金登录名"].ToString(), "验证用户登录名");

                //验证登录是否成功
                Log.Info("验证退出链接");
                CtripAssert.AreEqual<string>(driver, driver.FindElement(By.LinkText("退出")).Text, "退出", "验证退出链接");
                //验证会员等级
                Log.Info("验证会员等级");
                CtripAssert.AreEqual<string>(driver, driver.FindElement(By.ClassName("mc_grade")).Text, "白金贵宾", "验证会员等级");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }




    }
}
