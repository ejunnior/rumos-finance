using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Finance.Api
{
    using Application.Bank;
    using Application.Category;
    using Application.Creditor;
    using Application.Treasury;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using IdentityServer4.AccessTokenValidation;
    using Infrastructure.Data.BankAccount.Repository;
    using Infrastructure.Data.Category.Repository;
    using Infrastructure.Data.Creditor.Repository;
    using Infrastructure.Data.Payable.Repository;
    using Infrastructure.Data.UnitOfWork;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Finance.Api v1"));
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFinanceUnitOfWork, FinanceUnitOfWork>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBankAccountRepository, BankAccountRepository>();
            services.AddScoped<ICreditorRepository, CreditorRepository>();
            services.AddScoped<IPayableRepository, PayableRepository>();
            services.AddScoped<IRegisterBankAccountHandler, RegisterBankAccountHandler>();
            services.AddScoped<IEditBankAccountHandler, EditBankAccountHandler>();
            services.AddScoped<IDeleteBankAccountHandler, DeleteBankAccountHandler>();
            services.AddScoped<IRegisterCategoryHandler, RegisterCategoryHandler>();
            services.AddScoped<IEditCategoryHandler, EditCategoryHandler>();
            services.AddScoped<IDeleteCategoryHandler, DeleteCategoryHandler>();
            services.AddScoped<IRegisterCreditorHandler, RegisterCreditorHandler>();
            services.AddScoped<IDeleteCreditorHandler, DeleteCreditorHandler>();
            services.AddScoped<IEditCreditorHandler, EditCreditorHandler>();
            services.AddScoped<IRegisterPayableAccountHandler, RegisterPayableAccountHandler>();
            services.AddScoped<IEditPayableAccountHandler, EditPayableAccountHandler>();
            services.AddScoped<IDeletePayableAccountHandler, DeletePayableAccountHandler>();
            services.AddScoped<IGetCreditorByIdHandler, GetCreditorByIdHandler>();
            services.AddScoped<IGetCategoryByIdHandler, GetCategoryByIdHandler>();
            services.AddScoped<IGetPayableAccountByIdHandler, GetPayableAccountByIdHandler>();
            services.AddScoped<IGetBankAccountByIdHandler, GetBankAccountByIdHandler>();
            services.AddScoped<IGetPayableAccountHandler, GetPayableAccountHandler>();
            services.AddScoped<IGetCreditorHandler, GetCreditorHandler>();
            services.AddScoped<IGetCategoryHandler, GetCategoryHandler>();

            services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(
                    options =>
                    {
                        options.Authority = "https://localhost:44315/";
                        options.ApiName = "financeapi";
                    });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Finance.Api", Version = "v1" });
            });

            services.AddCors();
        }
    }
}