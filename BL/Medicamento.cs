using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Medicamento
    {
        public static ML.Result GetAll(int IdUsuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MarzanEntities context = new DL.MarzanEntities())
                {
                    var query = context.MedicamentosGetAll().ToList();
                    if (query.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var obj in query)
                        {
                            ML.Medicamento medicamento = new ML.Medicamento();
                            medicamento.IdMedicamneto = obj.IdMedicamento;
                            medicamento.Nombre = obj.Nombre;
                            medicamento.Precio = (decimal)obj.Precio;
                            medicamento.IdUsuario = IdUsuario;



                            result.Objects.Add(medicamento);
                        }
                        result.Correct = true;

                    }
                    else
                    {
                        result.Correct = false;
                    }
                }

            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessaage = ex.Message;
            }
            return result;
        }
    }
}
