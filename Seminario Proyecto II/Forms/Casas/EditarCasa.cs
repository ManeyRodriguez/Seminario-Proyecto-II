using Seminario_Proyecto_II.Data.Models;
using Seminario_Proyecto_II.Data.Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Seminario_Proyecto_II.Forms.Casas
{
    public partial class EditarCasa : Form
    {
        private readonly ICasaRepository _casaRepository;
        private readonly IResidenteRepository _residenteRepository;
        private Casa _casa;
        private Residente _residenteSeleccionado;

        public EditarCasa(int casaId, ICasaRepository casaRepository, IResidenteRepository residenteRepository)
        {
            InitializeComponent();
            _casaRepository = casaRepository;
            _residenteRepository = residenteRepository;
            CargarTipoCasa();
            CargarDatosCasa(casaId);
        }

        private void CargarTipoCasa()
        {
            if (!cmbTipo.Items.Contains("Casa"))
            {
                cmbTipo.Items.Add("Casa");
            }

            if (!cmbTipo.Items.Contains("Apartamento"))
            {
                cmbTipo.Items.Add("Apartamento");
            }
            cmbTipo.SelectedIndex = 0;
        }


        private async void CargarDatosCasa(int casaId)
        {
            try
            {
                _casa = await _casaRepository.ObtenerPorId(casaId);

                if (_casa != null)
                {
                    txtCalle.Text = _casa.Calle;
                    txtNumCasa.Text = _casa.NumCasa;
                    cmbTipo.SelectedItem = _casa.Tipo;

                    if (_casa.ResidenteId != null && _casa.ResidenteId > 0)
                    {
                        _residenteSeleccionado = await _residenteRepository.ObtenerPorId((int)_casa.ResidenteId);

                        if (_residenteSeleccionado != null)
                        {
                            lblResidenteActual.Text = "Residente Actual: " + _residenteSeleccionado.NombreCompleto;
                        }
                        else
                        {
                            lblResidenteActual.Text = "Residente Actual: No asignado";
                        }
                    }
                    else
                    {
                        lblResidenteActual.Text = "Residente Actual: No asignado";
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró la casa con el ID proporcionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos de la casa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private async void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_residenteSeleccionado == null)
                {
                    MessageBox.Show("Debe seleccionar un residente para asignar a la casa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _casa.Calle = txtCalle.Text.Trim();
                _casa.NumCasa = txtNumCasa.Text.Trim();
                _casa.Tipo = cmbTipo.SelectedItem.ToString();
                _casa.ResidenteId = _residenteSeleccionado.Id;

                await _casaRepository.Actualizar(_casa);


                DialogResult result = MessageBox.Show("Casa actualizada correctamente..", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (result == DialogResult.OK)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnBuscarResidente_Click(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtBuscarResidente.Text.Trim();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    MessageBox.Show("Por favor ingrese un término de búsqueda.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var residentes = await _residenteRepository.BuscarResidentes(searchTerm);
                lstResidentes.Items.Clear();

                if (residentes.Any())
                {
                    foreach (var residente in residentes)
                    {
                        lstResidentes.Items.Add(residente);
                    }
                }
                else
                {
                    MessageBox.Show("No se encontraron residentes con ese término de búsqueda.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LstResidentes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstResidentes.SelectedItem != null)
            {
                _residenteSeleccionado = (Residente)lstResidentes.SelectedItem;

                if (_residenteSeleccionado != null)
                {
                    lblResidenteActual.Text = "Residente Actual: " + _residenteSeleccionado.NombreCompleto;
                }
                else
                {
                    lblResidenteActual.Text = "Residente Actual: No válido o no seleccionado.";
                }
            }
        }

        private async void txtBuscarResidente_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                string searchTerm = txtBuscarResidente.Text.Trim();


                if (searchTerm.Length >= 3)
                {

                    try
                    {

                        var residentes = await _residenteRepository.BuscarResidentes(searchTerm);
                        lstResidentes.Items.Clear();

                        if (residentes.Any())
                        {
                            foreach (var residente in residentes)
                            {
                                lstResidentes.Items.Add(residente);
                            }
                        }
                       
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al buscar residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar residentes: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
