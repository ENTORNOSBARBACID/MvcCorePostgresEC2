using Microsoft.EntityFrameworkCore;
using MvcCorePostgresEC2.Data;
using MvcCorePostgresEC2.Models;

namespace MvcCorePostgresEC2.Repositories
{
    public class DepartamentoRepository
    {
        private HospitalContext context;
        public DepartamentoRepository(HospitalContext context)
        {
            this.context = context;
        }
        public async Task<List<Departamento>> LoadDepartamentosAsync()
        {
            return await this.context.Departamentos.ToListAsync();
        }
        public async Task<Departamento> FindDepartamentoAsync(int id)
        {
            return await this.context.Departamentos.FirstOrDefaultAsync(x => x.Dept_no == id);
        }
        public async Task CreateDepartamentoAsync(Departamento dept)
        {
            await this.context.Departamentos.AddAsync(dept);
            await this.context.SaveChangesAsync();
        }
    }
}
