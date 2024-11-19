using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using MongoDBProj.Domain.Interfaces;
using MongoDBProj.Infrastructure.DbContext;
using MongoDBProj.Infrastructure.Repositories;

namespace MongoDBProj.Infrastructure;
public static class DI
{
	public static IServiceCollection RegisterIntrastructure(this IServiceCollection services)
		=> services
				.AddScoped<IMongoDbContext, MongoDbContext>()
				.AddScoped<IMovieRepository, MovieRepository>();
}
