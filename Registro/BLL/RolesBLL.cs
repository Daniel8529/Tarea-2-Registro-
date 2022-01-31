
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System;

namespace Registro
{
    public class RolesBLL
    {
        public static bool Insertar(Roles roles)
        {
            bool paso = false;
            using (var contexto = new Contexto())
            {
                contexto.Roles.Add(roles);
                paso = contexto.SaveChanges() > 0;
            }
            return paso;
        }

       


        public static bool Editar(Roles roles)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //marcar la entidad como modificada para que el contexto sepa como proceder
                contexto.Entry(roles).State = EntityState.Modified;
               paso = contexto.SaveChanges() > 0;
               

             
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return paso;
        }

        public static bool Eliminar(String id)
        {
            bool m = false;

            Contexto contexto = new Contexto();

            try
            {
                //buscar la entidad que se desea eliminar
                var adicionales = contexto.Roles.Find(id);

                if (adicionales != null)
                {
                    contexto.Roles.Remove(adicionales); //remover la entidad
                    m= contexto.SaveChanges() > 0;
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return m;
        }
      
       
        public static bool Existe(Roles te,String id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            
             
            try
            {
                 encontrado = contexto.Roles.Any(e => e.Rolid== id);
                if(encontrado)
                {
                  
                  RolesBLL.Editar(te);
                }else{
                     Console.WriteLine("dddddd");
                }
               
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }
       
        
       public static bool Existe(string id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Roles.Any(e => e.Descripcion == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }

        //Este Exite es para saber si hay un Rolid igual
           public static bool Existes(string id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;
            try
            {
                encontrado = contexto.Roles.Any(e => e.Rolid== id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return encontrado;
        }


        public static List<Roles> GetLista()
        {
            using (var contexto = new Contexto())
            {
                return contexto.Roles.ToList();
            }
        }
    }
}
