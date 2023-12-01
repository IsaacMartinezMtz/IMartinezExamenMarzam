using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pedidos
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.PedidosGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in query)
                        {
                            ML.Pedidos pedidos = new ML.Pedidos();
                            pedidos.Usuario = new ML.Usuario();
                            pedidos.Medicamento = new ML.Medicamento();
                            pedidos.Usuario.IdUsuario = item.IdUsuario;
                            pedidos.Usuario.Nombre = item.Nombre;
                            pedidos.Usuario.ApellidoPaterno = item.ApellidoPaterno;
                            pedidos.Usuario.ApellidoMaterno = item.ApellidoMaterno;
                            pedidos.Medicamento.IdMedicamneto = item.IdMedicamento;
                            pedidos.Medicamento.Nombre = item.NombreMedicamento;
                            pedidos.Medicamento.Precio = (decimal)item.Precio;
                            pedidos.Cantidad = (int)item.Cantidad;
                            pedidos.Total = (decimal)item.Total;
                            pedidos.IdPedido = item.IdPedido;

                            result.Objects.Add(pedidos);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessaage = ex.Message;
            }
            return result;
        }
        public static ML.Result GetById(int IdPedido)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.PedidosGetById(IdPedido).FirstOrDefault();
                    result.Object = new List<object>();
                    if (query != null)
                    {
                        ML.Pedidos pedidos = new ML.Pedidos();
                        pedidos.Usuario = new ML.Usuario();
                        pedidos.Medicamento = new ML.Medicamento();
                        pedidos.Usuario.IdUsuario = query.IdUsuario;
                        pedidos.Usuario.Nombre = query.Nombre;
                        pedidos.Usuario.ApellidoMaterno = query.ApellidoMaterno;
                        pedidos.Usuario.ApellidoPaterno = query.ApellidoPaterno;
                        pedidos.Medicamento.IdMedicamneto = query.IdMedicamento;
                        pedidos.Medicamento.Nombre = query.NombreMedicamento;
                        pedidos.Medicamento.Precio = (decimal)query.Precio;
                        pedidos.Cantidad = (int)query.Cantidad;
                        pedidos.Total = (decimal)query.Total;
                        pedidos.IdPedido = query.IdPedido;

                        result.Object = pedidos;
                        result.Correct = true;
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage = ex.Message;
            }
            return result;
        }
        public static ML.Result PedidoAdd(ML.Pedidos pedidos)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    pedidos.Total = pedidos.Cantidad * pedidos.Costo;
                    var query = context.PedidoAdd(pedidos.Usuario.IdUsuario, pedidos.Medicamento.IdMedicamneto, pedidos.Cantidad, pedidos.Total);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage= ex.Message;
            }
            return result;
        }
        public static ML.Result PedidoUpdate(ML.Pedidos pedidos)
        {
            ML.Result result= new ML.Result();
            try
            {
                using (DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.PedidoUpdate(pedidos.IdPedido, pedidos.Usuario.IdUsuario, pedidos.Medicamento.IdMedicamneto, pedidos.Cantidad, pedidos.Total);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage = ex.Message;
            }
            return result;
        }
        public static ML.Result PedidosDelete(int IdPedido)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.PedidoDelete(IdPedido);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                    }
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage= ex.Message;
            }
            return result;
        }
    }
}
