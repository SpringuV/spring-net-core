// Tạo một builder để cấu hình ứng dụng web
// Builder này chứa tất cả các cài đặt và dịch vụ cần thiết

using first_with_aspnet_web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Thêm các dịch vụ Controllers và Views vào ứng dụng
// Điều này cho phép sử dụng mô hình MVC (Model-View-Controller)
builder.Services.AddControllersWithViews();
// add transient sẽ tạo ra một instance mới mỗi khi được yêu cầu
// add scoped sẽ tạo ra một instance mới cho mỗi request khác nhau
// add singleton sẽ tạo ra một instance duy nhất cho toàn bộ ứng dụng
builder.Services.AddSingleton<IRepository>(service => new MyRepository(service.GetRequiredService<ILogger<MyRepository>>()));
// Xây dựng ứng dụng web từ builder đã cấu hình
var app = builder.Build();

// Configure the HTTP request pipeline.
// Cấu hình pipeline xử lý các request HTTP

// Kiểm tra xem ứng dụng có đang chạy ở môi trường Development (phát triển) không
if (!app.Environment.IsDevelopment())
{
    // Nếu KHÔNG phải môi trường Development (tức là Production - sản xuất)
    // Sử dụng trang xử lý lỗi tùy chỉnh tại "/Home/Error"
    // Trang này sẽ hiển thị khi có lỗi xảy ra trong ứng dụng
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // Bật HSTS (HTTP Strict Transport Security)
    // HSTS yêu cầu trình duyệt luôn sử dụng HTTPS thay vì HTTP
    // Giúp bảo mật ứng dụng bằng cách ngăn chặn các cuộc tấn công man-in-the-middle
    app.UseHsts();
}

// Tự động chuyển hướng các request HTTP sang HTTPS
// Ví dụ: http://example.com -> https://example.com
app.UseHttpsRedirection();

// Cho phép ứng dụng phục vụ các file tĩnh
// Như: CSS, JavaScript, hình ảnh từ thư mục wwwroot
app.UseStaticFiles();

// Bật routing (định tuyến) cho ứng dụng
// Routing giúp ánh xạ URL đến các Controller và Action tương ứng
app.UseRouting();

// Bật middleware Authorization (phân quyền)
// Kiểm tra xem người dùng có quyền truy cập vào tài nguyên không
app.UseAuthorization();

// Cấu hình route mặc định cho ứng dụng MVC
// Pattern: {controller=Home}/{action=Index}/{id?}
// - controller=Home: Controller mặc định là HomeController
// - action=Index: Action mặc định là Index
// - id?: Tham số id là tùy chọn (dấu ? nghĩa là optional)
// Ví dụ: "/Home/Index", "/Products/Details/5", hoặc chỉ "/"
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// Chạy ứng dụng web
// Ứng dụng bắt đầu lắng nghe các request HTTP
app.Run();
