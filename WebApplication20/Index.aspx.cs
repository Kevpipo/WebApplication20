using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication20.ProductosTableAdapters;

namespace WebApplication20
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        protected void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            int cantidad = int.Parse(txtCantidad.Text);
            decimal costo = decimal.Parse(txtCosto.Text);
            byte[] imagenBytes = null;

            if (fileImagen.HasFile)
            {
                using (System.IO.BinaryReader br = new System.IO.BinaryReader(fileImagen.PostedFile.InputStream))
                {
                    imagenBytes = br.ReadBytes(fileImagen.PostedFile.ContentLength);
                }
            }

            productosTableAdapter productosAdapter = new productosTableAdapter();
            productosAdapter.InsertQuery(nombre, cantidad, costo, imagenBytes);

            CargarProductos();
        }

        private void CargarProductos()
        {
            productosTableAdapter productosAdapter = new productosTableAdapter();
            var productos = productosAdapter.GetData();
            gvProductos.DataSource = productos;
            gvProductos.DataBind();
        }

        // Método para convertir los datos de imagen en Base64 y enlazarlos con el GridView
        protected string GetImageUrl(RepeaterItem item)
        {
            // Recuperar el objeto del producto de los datos enlazados
            var producto = (System.Data.DataRowView)item.DataItem;

            // Convertir el arreglo de bytes en una imagen en base64
            byte[] imagenBytes = (byte[])producto["Imagen"];
            string base64String = Convert.ToBase64String(imagenBytes);

            // Crear una URL de datos (data URI) para mostrar la imagen
            return "data:image/jpeg;base64," + base64String;
        }

        // Manejo de evento RowDataBound para asignar correctamente la imagen
        protected void gvProductos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // Verificar si la fila es una fila de datos (no encabezado, pie, etc.)
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Obtener el valor de la imagen
                object imagenData = DataBinder.Eval(e.Row.DataItem, "Imagen");

                // Obtener el control de imagen en la fila
                Image imgProducto = (Image)e.Row.FindControl("imgProducto");

                // Verificar si la imagen es nula (DBNull) antes de intentar convertirla
                if (imagenData != DBNull.Value)
                {
                    byte[] imagenBytes = (byte[])imagenData;
                    string base64String = Convert.ToBase64String(imagenBytes);
                    imgProducto.ImageUrl = "data:image/jpeg;base64," + base64String;
                }
                else
                {
                    // Si la imagen es nula, asignamos una imagen por defecto (opcional)
                    imgProducto.ImageUrl = "~/images/noimage.jpg"; // Asegúrate de tener esta imagen en tu proyecto
                }
            }
        }

        // Método para convertir los datos de imagen en Base64 y enlazarlos con el GridView
        protected string GetImageUrl(object imagenData)
        {
            if (imagenData != DBNull.Value)
            {
                byte[] imagenBytes = (byte[])imagenData;
                string base64String = Convert.ToBase64String(imagenBytes);
                return "data:image/jpeg;base64," + base64String;
            }
            return string.Empty; // En caso de que no haya imagen
        }

    }
}
