using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ELearning;
using Back.Models;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Cors;
using ELearning.Commons;
using Microsoft.EntityFrameworkCore;
using ELearning.Services;
using System.Text.Json;
using Microsoft.AspNetCore.Authentication;
using ELearning.Models;
using ELearning.DTOs;
using ELearning.Commons.Constants;
using BC = BCrypt.Net.BCrypt;
using ELearning.DTOs.Auth;
using System.Security.Principal;

namespace ELearning.Controllers
{
    //[EnableCors(origins: "*", headers: "accept,content-type,origin,x-my-header", methods: "*")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IEmailSender sendMailService;
        private readonly ElearningContext elearningContext;

        public LoginController(ILogger<LoginController> logger, ElearningContext elearningContext, IConfiguration configuration, IEmailSender sendMailService)
        {
            _logger = logger;
            _configuration = configuration;
            this.elearningContext = elearningContext;
            this.sendMailService = sendMailService;
        }

        //[Route("/forgotpassword/{email}")]
        //[HttpGet]
        //public async Task<IActionResult> Forgotpassword(string email)
        //{
        //    var makkhachhang = await (from kh in elearningContext.Khachhang
        //                                     where kh.Email.Equals(email)
        //                                     select kh.Makhachhang).FirstOrDefaultAsync();
        //    var matkhau = await (from tkkh in elearningContext.Taikhoankhachhang
        //                    where tkkh.Makhachhang.Equals(makkhachhang)
        //                                     select tkkh.Password).FirstOrDefaultAsync();
        //    string htmlemail = $"mật khẩu của bạn là : "+matkhau+ " hãy sử dụng mật khẩu này để đăng nhập lại ";
        //    await sendMailService.SendEmailAsync(email, "lấy lại mật khẩu Lavender", htmlemail);
        //    return StatusCode(200);
        //}

        [Route("/register")]
        [HttpPost]
        public async Task<IActionResult> Register([FromForm] RegisterDTO registerDTO)
        {


            User temp = await (from x in elearningContext.Users
                               where x.Username.Equals(registerDTO.username)
                               select x).FirstOrDefaultAsync();

            if (temp != null) return StatusCode(409, Json(ErrorCode.USERNAME_ALREADY_EXISTS));



            User user = new();
            user.Username = registerDTO.username;
            user.Fullname = registerDTO.fullname;
            user.Email = registerDTO.email;
            user.Phone = registerDTO.phone;
            user.Password = BC.HashPassword(registerDTO.password);
            user.Role = EROLE.CLIENT;

            await elearningContext.AddAsync(user);
            await elearningContext.SaveChangesAsync();


            return StatusCode(200);
        }

        [Route("/login")]
        [HttpPost]
        public async Task<IActionResult> LoginKhachhangAsync(LoginDTO loginForm)
        {

            var user = await (from t in elearningContext.Users
                              where t.Username.Equals(loginForm.username)
                              select t).FirstOrDefaultAsync();
            if (user == null || !BC.Verify(loginForm.password, user.Password)) return Unauthorized();


            var token = MyTokenHandler.GenerateAccessToken(user.Username, MyTokenHandler.GUEST, _configuration);

            return StatusCode(200, Json(new { token, user }));
        }

        //[Route("/login-with-google")]
        //[HttpPost]
        //public async Task<IActionResult> LoginWithGoogle(JsonElement json)
        //{
        //    var khachhang = await (from x in elearningContext.Khachhang
        //                           where x.Email == json.GetString("email")
        //                           select x).FirstOrDefaultAsync();
        //    if (khachhang == null)
        //    {
        //        khachhang = new Khachhang();
        //        khachhang.Tenkhachhang = json.GetString("name");
        //        khachhang.Email = json.GetString("email");
        //        khachhang.Loaikhachhang = "Thành viên";
        //        khachhang.Image = json.GetString("imageUrl");
        //        await elearningContext.AddAsync(khachhang);
        //        await elearningContext.SaveChangesAsync();

        //        Khachhang khachhangtemp = await (from x in elearningContext.Khachhang
        //                                         where x.Email.Equals(json.GetString("email"))
        //                                         select x).FirstOrDefaultAsync();
        //        Taikhoankhachhang newtaikhoankhachhang = new Taikhoankhachhang();
        //        newtaikhoankhachhang.Makhachhang = khachhangtemp.Makhachhang;
        //        newtaikhoankhachhang.Googleid = json.GetString("googleId");
        //        newtaikhoankhachhang.Kichhoat = 1;

        //        await elearningContext.AddAsync(newtaikhoankhachhang);
        //        await elearningContext.SaveChangesAsync();
        //    }


        //    khachhang = await (from x in elearningContext.Khachhang
        //                       where x.Email == json.GetString("email")
        //                       select x).FirstOrDefaultAsync();
        //    if (khachhang == null) return StatusCode(401);

        //    var taikhoankhachhang = await (from x in elearningContext.Taikhoankhachhang
        //                                   where x.Makhachhang == khachhang.Makhachhang
        //                                   select x).FirstOrDefaultAsync();
        //    if (taikhoankhachhang==null)
        //    {
        //        taikhoankhachhang = new Taikhoankhachhang();
        //        taikhoankhachhang.Makhachhang = khachhang.Makhachhang;
        //        taikhoankhachhang.Kichhoat = 1;
        //        taikhoankhachhang.Googleid = json.GetString("googleId");
        //        await elearningContext.AddAsync(taikhoankhachhang);
        //    }

        //    if (string.IsNullOrEmpty(taikhoankhachhang.Googleid))
        //    {
        //        taikhoankhachhang.Googleid = json.GetString("googleId");
        //    }
        //    else if (taikhoankhachhang.Googleid!=json.GetString("googleId"))
        //    {
        //        return StatusCode(401);
        //    }


        //    var token = MyTokenHandler.GenerateAccessToken(khachhang.Makhachhang.ToString(), MyTokenHandler.GUEST, _configuration);
        //    var refreshtoken = MyTokenHandler.GenerateRefreshToken(khachhang.Makhachhang.ToString(), MyTokenHandler.GUEST, _configuration);

        //    Khachhangdangnhap khachhangdangnhap = new Khachhangdangnhap();
        //    khachhangdangnhap.Refreshtoken = refreshtoken;
        //    khachhangdangnhap.Makhachhang = khachhang.Makhachhang;

        //    await elearningContext.AddAsync(khachhangdangnhap);
        //    await elearningContext.SaveChangesAsync();
        //    return StatusCode(200, Json(new { token = token, refreshtoken = refreshtoken, makhachhang = khachhang.Makhachhang }));
        //}

        //[Route("/refresh-token")]
        //[HttpPost]
        //public async Task<IActionResult> RefreshToken(JsonElement json)
        //{
        //    string refreshtoken = json.GetString("refreshtoken");
        //    string ip = json.GetString("ip");

        //    Dictionary<string, string> payload = MyTokenHandler.TokenPayloadHandler(refreshtoken);
        //    if (payload["role"].Equals(MyTokenHandler.GUEST))
        //    {
        //        if (payload.IsNullOrEmpty()) return StatusCode(401);
        //        var taikhoan = await (from x in elearningContext.Taikhoankhachhang
        //                              where x.Makhachhang == int.Parse((payload["unique_name"]))
        //                              select x).FirstOrDefaultAsync();
        //        if (taikhoan == null) return StatusCode(401);

        //        var khachhangdangnhap = await (from x in elearningContext.Khachhangdangnhap
        //                                       where x.Refreshtoken.Equals(refreshtoken)
        //                                       select x).FirstOrDefaultAsync();
        //        if (khachhangdangnhap == null) return StatusCode(401);

        //        var newrefreshtoken = MyTokenHandler.GenerateRefreshToken(taikhoan.Makhachhang.ToString(), MyTokenHandler.GUEST, _configuration);

        //        var newkhachhangdangnhap = new Khachhangdangnhap();
        //        newkhachhangdangnhap.Refreshtoken = newrefreshtoken;
        //        newkhachhangdangnhap.Makhachhang = khachhangdangnhap.Makhachhang;
        //        newkhachhangdangnhap.Ip = ip;
        //        newkhachhangdangnhap.Thoidiem = DateTime.Now.ToLocalTime();
        //        elearningContext.Remove(khachhangdangnhap);

        //        await elearningContext.AddAsync(newkhachhangdangnhap);
        //        await elearningContext.SaveChangesAsync();

        //        var token = MyTokenHandler.GenerateAccessToken(taikhoan.Makhachhang.ToString(), MyTokenHandler.GUEST, _configuration);
        //        return StatusCode(200, Json(new { token = token, refreshtoken = newrefreshtoken, makhachhang = taikhoan.Makhachhang }));
        //    }
        //    else if (payload["role"].Equals(MyTokenHandler.ADMINISTRATOR) || payload["role"].Equals(MyTokenHandler.STAFF))
        //    {
        //        if (payload.IsNullOrEmpty()) return StatusCode(401);
        //        var taikhoan = await (from x in elearningContext.Taikhoannhanvien
        //                              where x.Manhanvien == int.Parse((payload["unique_name"]))
        //                              select x).FirstOrDefaultAsync();
        //        if (taikhoan == null) return StatusCode(401);

        //        var nhanviendangnhap = await (from x in elearningContext.Nhanviendangnhap
        //                                      where x.Refreshtoken.Equals(refreshtoken)
        //                                      select x).FirstOrDefaultAsync();
        //        if (nhanviendangnhap == null) return StatusCode(401);

        //        var newrefreshtoken = MyTokenHandler.GenerateRefreshToken(taikhoan.Manhanvien.ToString(), payload["role"], _configuration);

        //        var newnhanviendangnhap = new Nhanviendangnhap();
        //        newnhanviendangnhap.Refreshtoken = newrefreshtoken;
        //        newnhanviendangnhap.Manhanvien = nhanviendangnhap.Manhanvien;
        //        newnhanviendangnhap.Ip = ip;
        //        newnhanviendangnhap.Thoidiem = DateTime.Now.ToLocalTime();
        //        elearningContext.Remove(nhanviendangnhap);

        //        await elearningContext.AddAsync(newnhanviendangnhap);
        //        await elearningContext.SaveChangesAsync();

        //        var token = MyTokenHandler.GenerateAccessToken(taikhoan.Manhanvien.ToString(), payload["role"], _configuration);
        //        return StatusCode(200, Json(new { token = token, refreshtoken = newrefreshtoken, manhanvien = taikhoan.Manhanvien }));
        //    }
        //    return StatusCode(204);
        //}

        [Route("/test")]
        [AllowAnonymous]
        public IActionResult test()
        {
            //await sendMailService.SendEmailAsync("khanhlemaiduy123@gmail.com", "test", "a");
            //CookieOptions option = new CookieOptions
            //{
            //    Expires = DateTime.Now.AddHours(4),
            //    Path = "/",
            //    HttpOnly = false,

            //};

            //HttpContext.Session.SetString("khanhzum", "a");
            //var sessionValue = HttpContext.Request.Cookies["token"];
            //Console.WriteLine("session" + sessionValue);


            //CookieOptions option = new CookieOptions
            //{
            //    Expires = DateTime.Now.AddHours(4),
            //    Path = "/",
            //    HttpOnly = false,

            //};
            //Response.Cookies.Append("token", "aa", option);
            //Console.WriteLine("cookie"+HttpContext.Request.Cookies["token"]);
            Response.Cookies.Append("token", "aa");
            var listcokie = HttpContext.Request.Cookies.Select((header) => $"{header.Key}: {header.Value}");
            Console.WriteLine("listcooke" + listcokie.ToString());
            Console.WriteLine("cookie" + HttpContext.Request.Cookies["token"]);
            return StatusCode(200);
        }

        //[Route("/logout")]
        //[HttpPost]
        //[Authorize]
        //public async Task<IActionResult> Logout(JsonElement json)
        //{
        //    if (json.GetString("loaitaikhoan").Equals("khachhang"))
        //    {
        //        int makhachhang = int.Parse(json.GetString("ma"));
        //        string refreshtoken = json.GetString("refreshtoken");

        //        var khachhangdangnhap = await (from x in elearningContext.Khachhangdangnhap
        //                                       where x.Makhachhang == makhachhang
        //                                       && x.Refreshtoken.Equals(refreshtoken)
        //                                       select x).FirstOrDefaultAsync();
        //        if (khachhangdangnhap == null) return StatusCode(404);
        //        elearningContext.Remove(khachhangdangnhap);
        //        await elearningContext.SaveChangesAsync();
        //        return StatusCode(200, Json(makhachhang));
        //    }
        //    else if (json.GetString("loaitaikhoan").Equals("nhanvien"))
        //    {
        //        int manhanvien = int.Parse(json.GetString("ma"));
        //        string refreshtoken = json.GetString("refreshtoken");

        //        var nhanviendangnhap = await (from x in elearningContext.Nhanviendangnhap
        //                                      where x.Manhanvien == manhanvien
        //                                      && x.Refreshtoken.Equals(refreshtoken)
        //                                      select x).FirstOrDefaultAsync();
        //        if (nhanviendangnhap == null) return StatusCode(404);
        //        elearningContext.Remove(nhanviendangnhap);
        //        await elearningContext.SaveChangesAsync();
        //        return StatusCode(200, Json(nhanviendangnhap));
        //    }
        //    return StatusCode(204);
        //}


    }
}
