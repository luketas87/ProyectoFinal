using System;
using System.Linq;
using System.Windows.Forms;
using Autofac;
using BLL.implementacion;
using BE.Interfaces;
using DAL.DAO.Implementacion;
using DAL.DAO.Interfaces;
using ProyectoFinal.Formularios;
using BE.Implementacion;
using BLL.Interfaces;
using ProyectoFinal;
using ProyectoFinal.Clases;
using Servicios.Excepciones;

namespace UI
{
    public static class IoCContainer
    {
        private static IContainer container;
        static IoCContainer()
        {
            container = CreateContainer();
        }

        //Suplantar por el que esta comentado
      /*  private static IContainer CreateContainer()
        {
            throw new NotImplementedException();
        }*/

        public static T Resolve<T>()
        {
            try
            {
                return container.Resolve<T>();
            }
            catch (ConectionStringFaltanteException)
            {

                throw new ConectionStringFaltanteException();
            }

            catch (ErrorGenerico)
            {

                throw new ConectionStringFaltanteException();
                //MessageBox.Show("a ver que llega aca?" ,ex.Message);

            }


        }

        private static IContainer CreateContainer()
         {
             ////contBuilder.Register((ctx) => Principal.GetInstancia()).As<IPrincipal>().SingleInstance();
             var contBuilder = new ContainerBuilder();
             contBuilder.RegisterType<MenuPrincipal>().As<IPrincipal>().SingleInstance();
             contBuilder.RegisterType<MenuPrimcipal>().As<IPrimcipal>().SingleInstance();
             contBuilder.RegisterType<DALCuentaUsuario>().As<DALICuentaUsuario>().SingleInstance();
             contBuilder.RegisterType<BLLCuentaUsuario>().As<BLLICuentaUsuario>().SingleInstance();
             contBuilder.RegisterType<BLLVenta>().As<BLLIVenta>().SingleInstance();
             contBuilder.RegisterType<DALVenta>().As<DALIVenta>().SingleInstance();
             contBuilder.RegisterType<BLLFormControl>().As<BLLIFormControl>().SingleInstance();
             contBuilder.RegisterType<DALFormControl>().As<DALIFormControl>().SingleInstance();
             contBuilder.RegisterType<DALDigitoVerificador>().As<IDigitoVerificador>().InstancePerDependency();
             contBuilder.RegisterType<DetalleVenta>().As<IDetalleVenta>().SingleInstance();
             contBuilder.RegisterType<ABMusuario>().As<IABMUsuario>().SingleInstance();
             contBuilder.RegisterType<ABMusers>().As<IABMUsers>().SingleInstance();
             contBuilder.RegisterType<Bitacora>().As<IBitacora>().SingleInstance();
             contBuilder.RegisterType<BLLBitacora>().As<BLLIBitacora>().InstancePerDependency();
             contBuilder.RegisterType<DALBitacora>().As<DALIBitacora>().InstancePerDependency();
             contBuilder.RegisterType<FormControl>().As<IFormControl>().SingleInstance();
             contBuilder.RegisterType<Familias>().As<IFamilias>().SingleInstance();
             contBuilder.RegisterType<BLLFamilia>().As<BLLIFamilia>().InstancePerDependency();
             contBuilder.RegisterType<DALFamilia>().As<DALIFamilia>().InstancePerDependency();
             contBuilder.RegisterType<BLLPatente>().As<BLLIPatente>().InstancePerDependency();
             contBuilder.RegisterType<DALPatente>().As<DALIPatente>().InstancePerDependency();
             contBuilder.RegisterType<BLLProducto>().As<BLLIProducto>().SingleInstance();
             contBuilder.RegisterType<DALProducto>().As<DALIProducto>().SingleInstance();
             contBuilder.RegisterType<Productos>().As<IProductos>().SingleInstance();
             contBuilder.RegisterType<AdmPatenteFamilia>().As<IAdminPatFamilia>().SingleInstance();
             contBuilder.RegisterType<DatosUsuario>().As<IDatosUsuario>().SingleInstance();
             contBuilder.RegisterType<Clientes>().As<IClientes>().SingleInstance();
             contBuilder.RegisterType<BLLCliente>().As<BLLICliente>().SingleInstance();
             contBuilder.RegisterType<DALCliente>().As<DALICliente>().SingleInstance();
             contBuilder.RegisterType<Backup>().As<IBackup>().SingleInstance();
             contBuilder.RegisterType<Restore>().As<IRestore>().SingleInstance();
             contBuilder.RegisterType<BLLIdioma>().As<BLLIIdioma>().SingleInstance();
             contBuilder.RegisterType<DALIdioma>().As<DALIIdioma>().SingleInstance();
             contBuilder.RegisterType<DALDigitoVerificador>().As<IDigitoVerificador>().SingleInstance();
             contBuilder.RegisterType<BloqueoProductos>().As<IBloqueoProductos>().SingleInstance();
             contBuilder.RegisterType<BloqueoUsuario>().As<IBloqueoUsuario>().SingleInstance();
             contBuilder.RegisterType<AdminFamiliaUsuario>().As<IAdminFam>().SingleInstance();
             contBuilder.RegisterType<AdminPatenteUsuario>().As<IAdminPatentes>().SingleInstance();
             contBuilder.RegisterType<NegarPatenteUsuario>().As<INegarPat>().SingleInstance();
             contBuilder.RegisterType<DALDetalleVenta>().As<DALIDetalleVenta>().SingleInstance();
             contBuilder.RegisterType<BLLDetalleVenta>().As<BLLIDetalleVenta>().SingleInstance();
             contBuilder.RegisterType<Traductor>().As<ITraductor>().SingleInstance();
             contBuilder.RegisterType<Venta>().As<IVenta>().SingleInstance();
             contBuilder.RegisterType<DetalleRefForm>().As<IDetalleRefForm>().SingleInstance();
             return contBuilder.Build();
        }
    }
}
