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
    [Name("用户信息")]
    public class YongHuXinXi : PlatFormBaseTestCase
    {

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-个人中心菜单验证")]

        public void YongHuXinXi001()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证个人中心菜单收起
                Log.Info("验证个人中心菜单默认收起");
                Boolean flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyAccount"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "个人中心菜单默认收起");
                //验证个人中心菜单展开
                Log.Info("验证个人中心菜单展开");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyAccount"));
                CtripAssert.AreEqual(driver, flag.ToString(), "True", "个人中心菜单已展开");
            }

            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
       
        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-个人账户验证")]

        public void YongHuXinXi002()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //展开个人中心菜单
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyAccount")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {

                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);

                }
                Thread.Sleep(MinSleepTime);
                CtripAssert.Contains(driver, driver.FindElement(By.Id("info_title_id")).Text, "个人信息设置", "验证个人账户链接跳转");
                //修改个人信息
                driver.FindElement(By.Id("nickName")).Clear();
                driver.FindElement(By.Id("nickName")).SendKeys("一统江湖");
                driver.FindElement(By.Id("name")).Click();
                driver.FindElement(By.Id("name")).Clear();
                driver.FindElement(By.Id("name")).SendKeys("东方不败");
                driver.FindElement(By.Id("radioSexWoman")).Click();
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("infoUpdateConfirmPwd")).Click();
                driver.FindElement(By.Id("infoUpdateConfirmPwd")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.Id("btnInfoUpdateConfirm")).Click();
                Thread.Sleep(MIDSleepTime);
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//container/div[2]/div[2]/div[1]")).Text, "信息修改成功", "修改个人信息成功");
                Thread.Sleep(MIDSleepTime);
                driver.FindElement(By.Id("btnInfoUpdateSuccessConfirm")).Click();
                Thread.Sleep(MIDSleepTime);
                bool flag = driver.FindElement(By.Id("radioSexWoman")).Selected;
                CtripAssert.AreEqual(driver, flag.ToString(), "True", "");
                CtripAssert.AreEqual(driver, driver.FindElement(By.Id("nickName")).GetAttribute("value"),"一统江湖","");
                CtripAssert.AreEqual(driver, driver.FindElement(By.Id("name")).GetAttribute("value"), "东方不败", "修改成功");
                //数据回滚
                driver.FindElement(By.Id("nickName")).Clear();
                driver.FindElement(By.Id("nickName")).SendKeys("独步天下");
                driver.FindElement(By.Id("name")).Click();
                driver.FindElement(By.Id("name")).Clear();
                driver.FindElement(By.Id("name")).SendKeys("令狐冲");
                driver.FindElement(By.Id("radioSexMan")).Click();
                driver.FindElement(By.Id("btnSave")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("infoUpdateConfirmPwd")).Click();
                driver.FindElement(By.Id("infoUpdateConfirmPwd")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.Id("btnInfoUpdateConfirm")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("btnInfoUpdateSuccessConfirm")).Click();
                Thread.Sleep(MinSleepTime);
                //修改个人密码
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/div/h3")).Click();
                driver.FindElement(By.Id("oldPwd")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.Id("newPwd")).SendKeys("111111");
                driver.FindElement(By.Id("confirmNewPwd")).SendKeys("111111");
                driver.FindElement(By.Id("btnPwdSave")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.Contains(driver,"密码修改成功。",driver.FindElement(By.XPath("//container/div[2]/div[2]/div[1]")).Text,"密码修改功能验证");
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("btnPwdUpdateSuccessConfirm")).Click();
                Thread.Sleep(MIDSleepTime);
                //数据回滚
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/div/h3")).Click();
                driver.FindElement(By.Id("oldPwd")).SendKeys("111111");
                driver.FindElement(By.Id("newPwd")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.Id("confirmNewPwd")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.Id("btnPwdSave")).Click();
                Thread.Sleep(MIDSleepTime);
                driver.FindElement(By.XPath("//container/div[2]/div[2]/div[1]")).Click();
             }

            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }
        
        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-我的积分链接与列表验证")]
        public void YongHuXinXi003()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证我的积分链接存在并点击
                Log.Info("个人中心我的积分链接验证");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyMileage")).Click();
                //证书判断
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MIDSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//form/ul/li/div[1]")).Text, "我的积分", "验证跳转链接是否正确");
                //验证兑换记录列表
                driver.FindElement(By.Id("btnExchangeHistory")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("inputSearchExchangLog")).SendKeys("2575");
                driver.FindElement(By.Id("btnSearch")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[3]/div[1]/table/tbody/tr/td[2]")).Text, "积分优化换游票525", "验证兑换记录列表显示正确");
                //验证积分明细列表
                driver.FindElement(By.Id("btnMileageDetail")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/div[1]/table/tbody/tr[1]/td[1]")).Text, "2013-04-12", "验证积分明细列表显示正确");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-我的票券链接验证")]
        public void YongHuXinXi004()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证我的票券链接存在并点击
                Log.Info("个人中心我的票券链接验证");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyTicket")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MIDSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//div[@class='breadcrumb']")).Text,"我的票券","验证跳转链接是否正确");
                
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-我的点评链接验证")]
        public void YongHuXinXi005()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证我的点评链接存在并点击
                Log.Info("个人中心我的点评链接");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyReviews")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//div[@class='breadcrumb']")).Text, "我的点评", "验证跳转链接是否正确");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-消息提醒链接验证")]
        public void YongHuXinXi006()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证我的点评链接存在并点击
                Log.Info("个人中心消息提醒链接");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MessageRemind")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证列表显示正确
                driver.FindElement(By.Id("txt_Key")).SendKeys("奖品");
                driver.FindElement(By.Id("bt_Search")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/div[2]/table/tbody/tr[1]/td[2]")).Text, "申领奖品", "验证消息列表显示正确");
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-常用信用卡链接验证")]
        public void YongHuXinXi007()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证常用信用卡链接存在并点击
                Log.Info("个人中心常用信用卡链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[2]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_ucPageLeft_MyCard")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//div[@class='breadcrumb']")).Text, "常用信用卡", "验证跳转链接是否正确");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-第三方账号绑定链接验证")]
        public void YongHuXinXi008()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证第三方账号绑定链接存在并点击
                Log.Info("个人中心第三方账号绑定链接");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[2]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_ThirdBind")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证跳转链接正确
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//div[@class='breadcrumb']")).Text, "第三方账号绑定", "验证跳转链接是否正确");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("常用信息管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-常用信息管理菜单验证")]

        public void YongHuXinXi009()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证常用信息管理菜单收起
                Log.Info("验证常用信息管理菜单默认收起");
                Boolean flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_Passenger"));
                CtripAssert.AreEqual(driver, flag.ToString(), "False", "常用信息管理菜单默认收起");
                //验证常用信息管理菜单展开
                Log.Info("验证常用信息管理菜单展开");
                driver.FindElement(By.XPath("//ul/li/div[2]/dl[3]/dt/span")).Click();
                Thread.Sleep(MinSleepTime);
                flag = SeleniumFun.IsVisible(driver, By.Id("ctl00_MainContentPlaceHolder_PageLeft1_Passenger"));
                CtripAssert.AreEqual(driver, flag.ToString(), "True", "常用信息管理菜单已展开");
            }

            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("常用信息管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-常用旅客信息链接验证与修改")]
        public void YongHuXinXi010()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());
                Thread.Sleep(MinSleepTime);
                //验证常用旅客信息链接存在并点击
                Log.Info("验证常用旅客信息链接");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_menu_manage_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_Passenger")).Click();
                //证书判断
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MinSleepTime);
                //验证列表显示正常
                driver.FindElement(By.Id("txt_keyword")).SendKeys("test");
                driver.FindElement(By.Id("bt_Search")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver,driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr[1]/td[2]")).Text,"test/test","列表显示正常");
                //修改常用旅客信息
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr[1]/td[9]/a[1]")).Click();
                Thread.Sleep(MIDSleepTime);
                driver.FindElement(By.Id("txt_namecn")).Clear();
                driver.FindElement(By.Id("txt_namecn")).SendKeys("令狐冲");
                driver.FindElement(By.Id("txt_mobile")).Clear();
                driver.FindElement(By.Id("txt_mobile")).SendKeys("13888888888");
                SeleniumFun.SelectByText(driver.FindElement(By.ClassName("vam")), "身份证");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[1]")).Clear();
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[1]")).SendKeys("21080219900409251x");
                driver.FindElement(By.Id("bt_SaveAdd")).Click();
                driver.FindElement(By.Id("input_pwd_check")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.ClassName("btn_l3")).Click();
                Thread.Sleep(MinSleepTime);
                //验证修改是否正确
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr[1]/td[9]/a[1]")).Click();
                CtripAssert.AreEqual(driver, driver.FindElement(By.Id("txt_namecn")).GetAttribute("value"), "令狐冲");
                CtripAssert.AreEqual(driver,driver.FindElement(By.Id("txt_mobile")).GetAttribute("value"),"13888888888");
                CtripAssert.AreEqual(driver, driver.FindElement(By.ClassName("vam")).GetAttribute("value"), "1");
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[1]")).GetAttribute("value"), "21080219900409251x", "修改成功");
                //数据回滚
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr[1]/td[9]/a[1]")).Click();
                Thread.Sleep(MIDSleepTime);
                driver.FindElement(By.Id("txt_namecn")).Clear();
                driver.FindElement(By.Id("txt_mobile")).Clear();
                driver.FindElement(By.Id("txt_mobile")).SendKeys("13111111111");
                SeleniumFun.SelectByText(driver.FindElement(By.ClassName("vam")), "护照");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[1]")).Clear();
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[1]")).SendKeys("chinesehz001");
                driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/div[2]/div[3]/ul/li[1]/input[2]")).SendKeys("2015-01-01");
                driver.FindElement(By.Id("bt_SaveAdd")).Click();
                driver.FindElement(By.Id("input_pwd_check")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.ClassName("btn_l3")).Click();
                Thread.Sleep(MinSleepTime);
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("常用信息管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-常住酒店链接验证与修改")]
        public void YongHuXinXi011()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证常用旅客信息链接存在并点击
                Log.Info("验证常住酒店链接");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_menu_manage_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_UsualHotel")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证列表显示正常
                driver.FindElement(By.Id("txt_keyword")).SendKeys("6+1");
                driver.FindElement(By.Id("bt_Search")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[5]/table/tbody/tr/td[2]/a")).Text, "6+1酒店连锁（上海陆家嘴店）（原路依斯康商务酒店）", "列表显示正常");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("常用信息管理验证"), Category("我的携程2.0"), Author("周营")]
        [Name("用户信息-常用地址链接验证与修改")]
        public void YongHuXinXi012()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证常用地址信息链接存在并点击
                Log.Info("验证常用旅客信息链接");
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_menu_manage_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_UsefulAddress")).Click();
                //证书判断
                if (SeleniumFun.IsExists(driver, By.Id("overridelink")))
                {
                    driver.FindElement(By.Id("overridelink")).Click();
                    Thread.Sleep(3000);
                }
                Thread.Sleep(MinSleepTime);
                //验证列表显示正常
                driver.FindElement(By.Id("txt_keyword")).SendKeys("公司");
                driver.FindElement(By.Id("bt_Search")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr/td[2]")).Text, "公司","验证列表显示是否正常");
                //修改常用地址                
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr/td[9]/a[1]")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("txt_Rep")).Clear();
                driver.FindElement(By.Id("txt_Rep")).SendKeys("令狐冲");
                driver.FindElement(By.Id("bt_SaveAdd")).Click();
                driver.FindElement(By.Id("input_pwd_check")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.ClassName("btn_l3")).Click();
                Thread.Sleep(MinSleepTime);
                //验证修改是否成功
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr/td[9]/a[1]")).Click();
                Thread.Sleep(MinSleepTime);
                CtripAssert.AreEqual(driver, driver.FindElement(By.Id("txt_Rep")).GetAttribute("value"), "令狐冲", "修改成功");
                //数据回滚
                driver.FindElement(By.XPath("//ul/li/div[3]/div[2]/table/tbody/tr/td[9]/a[1]")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("txt_Rep")).Clear();
                driver.FindElement(By.Id("txt_Rep")).SendKeys("测试");
                driver.FindElement(By.Id("bt_SaveAdd")).Click();
                driver.FindElement(By.Id("input_pwd_check")).SendKeys(UserHT["测试用户登陆密码"].ToString());
                driver.FindElement(By.ClassName("btn_l3")).Click();
                Thread.Sleep(MinSleepTime);               
            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }

        [Test, Description("个人中心验证"), Category("我的携程2.0"), Author("周营")]
        [Name("个人中心-我的信用卡")]
        public void YongHuXinXi013()
        {
            try
            {
                Log.Info("开始执行用例");
                //打开首页
                baseURL = UserHT["url"].ToString();
                driver.Navigate().GoToUrl(baseURL);
                //登录
                LoginOn loginOn = new LoginOn(driver);
                loginOn.CNLoginOn(UserHT["测试用户登录名"].ToString(), UserHT["测试用户登陆密码"].ToString());

                Thread.Sleep(MinSleepTime);

                //验证我的信用卡链接存在并点击
                Log.Info("验证我的信用卡链接");
                driver.FindElement(By.Id("menu_person_icon_id")).Click();
                Thread.Sleep(MinSleepTime);
                driver.FindElement(By.Id("ctl00_MainContentPlaceHolder_PageLeft1_MyCard")).Click();
                //证书判断
                SeleniumFun.CheckSecurity(driver);
                Thread.Sleep(MinSleepTime);
                //验证列表显示正常
                CtripAssert.Contains(driver, driver.FindElement(By.XPath("//ul/li/div[3]/div/table/tbody/tr[1]/td[2]")).Text, "中国招商银行", "验证列表显示正常");

            }
            catch (Exception e)
            {
                new CtripException(driver, e.ToString(), this.GetType().ToString(), MethodBase.GetCurrentMethod().ToString());
            }
        }


    }
}
      
        
      