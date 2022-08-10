using MediatR;
using PrettyRoad.DAL;
using PrettyRoad.UserService.Extensions;
using PrettyRoad.UserService.Requests;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvcCore();
builder.Services.AddMediatR(x => x.AsScoped(), typeof(Program));

builder.Services.AddDAL();

var app = builder.Build();
app.MediatePost<UserRegisterRequest>("api/user/register");
app.MediateGet<FindUserRequest>("api/user");

app.Run();
