var builder = WebApplication.CreateBuilder(args);

// 加入 Controller 服務
builder.Services.AddControllers();
// 加入 Swagger (API 文件生成工具)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 設定 HTTP Request Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 這裡不需要 HttpsRedirection，因為在 Docker 內部通常走 HTTP，HTTPS 交由反向代理處理
// app.UseHttpsRedirection(); 

app.UseAuthorization();

app.MapControllers();

// 設定 API 監聽所有 IP 的 8080 Port (符合現代容器標準)
app.Run();