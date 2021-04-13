using Klinik.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Klinik
{
    public partial class Patient : System.Web.UI.Page
    {
        Connection _conn;
        Utilities _util; 

        public Patient()
        {
            _conn = new Connection();
            _util = new Utilities();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }


        }
        private void LoadData()
        {
            pnlAdd.Visible = true;
            pnlGrid.Visible = true;
            pnlForm.Visible = false;

            DataTable data = _conn.ExecQuery("select * from Patient_TB");

            dgvData.DataSource = data;
            dgvData.DataBind();



            dgvData.Visible = true;
        }

        private void LoadDataDetail(string id)
        {

            DataTable data = _conn.ExecQuery("select Patient_PK,a.Name_VC, Id_VC , Address_VC ,  POB_VC,DOB_DT, Email_VC,Phone1_VC, Phone2_VC, "
                                            + "    Remark_VC, d.Province_PK, c.City_PK, Districts_FK, Profession_FK, MartialStatus_FK, Religion_FK "
                                            + "from Patient_TB a "
                                            +"left join Districts_TB b on a.Districts_FK = b.Districts_PK "
                                            +"left join City_TB c on b.City_FK = c.City_PK "
                                            +"left join Province_TB d on c.Province_FK = d.Province_PK "
                                            +"where a.Patient_PK='"+ id + "'");

            this.hidPatientPK.Value = data.Rows[0].ItemArray[0].ToString();
            this.txtName.Text = data.Rows[0].ItemArray[1].ToString();
            this.txtId.Text = data.Rows[0].ItemArray[2].ToString();
            this.txtAddress.Text = data.Rows[0].ItemArray[3].ToString();
            this.txtPOB.Text = data.Rows[0].ItemArray[4].ToString();
            this.txtDOB.Text = data.Rows[0].ItemArray[5].ToString();
            this.txtEmail.Text = data.Rows[0].ItemArray[6].ToString();
            this.txtPhone1.Text = data.Rows[0].ItemArray[7].ToString();
            this.txtPhone2.Text = data.Rows[0].ItemArray[8].ToString();
            this.txtRemark.Text = data.Rows[0].ItemArray[9].ToString();
            LoadDataProvince();
            this.drpProvince.SelectedValue = data.Rows[0].ItemArray[10].ToString();
            LoadDataCity();
            this.drpCity.SelectedValue = data.Rows[0].ItemArray[11].ToString();
            LoadDataDistrict();
            this.drpDistrict.SelectedValue = data.Rows[0].ItemArray[12].ToString();
            LoadDataProfession();
            this.drpProfession.SelectedValue = data.Rows[0].ItemArray[13].ToString();
            LoadDataMartialStatus();
            this.drpMartialStatus.SelectedValue = data.Rows[0].ItemArray[14].ToString();
            LoadDataReligion();
            this.drpReligion.SelectedValue = data.Rows[0].ItemArray[15].ToString();


            pnlAdd.Visible = false;
            pnlGrid.Visible = false;
            pnlForm.Visible = true;

        }

        private void LoadDataProvince()
        {
            DataTable data = _conn.ExecQuery("select Province_PK,Name_VC from Province_TB order by Name_VC asc");

            this.drpProvince.Items.Clear();
            this.drpProvince.Items.Add("Choose...");

            for(int i = 0;i < data.Rows.Count;i++)
            {
                this.drpProvince.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
            }
        }

        private void LoadDataCity() {
            this.drpCity.Items.Clear();
            this.drpCity.Items.Add("Choose...");

            this.drpDistrict.Items.Clear();
            this.drpDistrict.Items.Add("Choose...");
            if (this.drpProvince.SelectedIndex.Equals(0))
            {

                drpCity.Enabled = false;
                drpDistrict.Enabled = false;
            }
            else
            {
                DataTable data = _conn.ExecQuery("select City_PK, Name_VC from City_TB where Province_FK ='" + this.drpProvince.SelectedValue + "' order by Name_VC asc");

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    this.drpCity.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
                }

                drpCity.Enabled = true;
            }
        }

        private void LoadDataDistrict() {
            this.drpDistrict.Items.Clear();
            this.drpDistrict.Items.Add("Choose...");
            if (this.drpCity.SelectedIndex.Equals(0))
            {

                drpDistrict.Enabled = false;
            }
            else
            {
                DataTable data = _conn.ExecQuery("select Districts_PK, Name_VC from Districts_TB where City_FK ='" + this.drpCity.SelectedValue + "' order by Name_VC asc");

                for (int i = 0; i < data.Rows.Count; i++)
                {
                    this.drpDistrict.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
                }

                drpDistrict.Enabled = true;
            }
        }

        private void LoadDataProfession()
        {
            DataTable data = _conn.ExecQuery("select Profession_PK,Name_VC from Profession_TB order by Name_VC asc");

            this.drpProfession.Items.Clear();
            this.drpProfession.Items.Add("Choose...");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                this.drpProfession.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
            }
        }

        private void LoadDataMartialStatus()
        {
            DataTable data = _conn.ExecQuery("select MartialStatus_PK,Name_VC from MartialStatus_TB order by Name_VC asc");

            this.drpMartialStatus.Items.Clear();
            this.drpMartialStatus.Items.Add("Choose...");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                this.drpMartialStatus.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
            }
        }

        private void LoadDataReligion()
        {
            DataTable data = _conn.ExecQuery("select Religion_PK,Name_VC from Religion_TB order by Name_VC asc");

            this.drpReligion.Items.Clear();
            this.drpReligion.Items.Add("Choose...");

            for (int i = 0; i < data.Rows.Count; i++)
            {
                this.drpReligion.Items.Add(new ListItem(data.Rows[i].ItemArray[1].ToString(), data.Rows[i].ItemArray[0].ToString()));
            }
        }
        protected void dgvData_RowCommand(Object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Detail")
            {
                int index = Convert.ToInt32(e.CommandArgument) - (dgvData.PageSize * dgvData.PageIndex);
                GridViewRow row = dgvData.Rows[index];

                Label lblId = (Label)dgvData.Rows[index].FindControl("lblPatientPK");

                LoadDataDetail(lblId.Text.ToString());
                //ViewDetail(Convert.ToInt32(lblId.Text));
            }
        }

        private void Save()
        {
            ListDictionary lstParams = new ListDictionary();
            string patientPK = this.hidPatientPK.Value.ToString();

            string Name = txtName.Text ;
            string Id = txtId.Text ;
            string Address = txtAddress.Text;
            string POB = txtPOB.Text ;
            string DOB = txtDOB.Text;
            string Email = txtEmail.Text ;
            string Phone1 = txtPhone1.Text ;
            string Phone2 = txtPhone2.Text;
            string Remark = txtRemark.Text;
            string District = drpDistrict.SelectedIndex != 0? drpDistrict.SelectedValue : "";
            string Profession = drpProfession.SelectedIndex != 0 ? drpProfession.SelectedValue : "";
            string MartialStatus = drpMartialStatus.SelectedIndex != 0 ? drpMartialStatus.SelectedValue : "";
            string Religion = drpReligion.SelectedIndex != 0 ? drpReligion.SelectedValue : "";

            if (!string.IsNullOrEmpty(patientPK)) {
                lstParams["@Patient_PK"] = patientPK;
            }
            else
            {
                lstParams["@Patient_PK"] = DBNull.Value;
            }
            lstParams["@Name_VC"] = Name;
            lstParams["@Id_VC"] = Id;
            lstParams["@Address_VC"] = Address;
            lstParams["@POB_VC"] = POB;
            lstParams["@DOB_VC"] = DOB;
            lstParams["@Email_VC"] = Email;
            lstParams["@Phone1_VC"] = Phone1;
            lstParams["@Phone2_VC"] = Phone2;
            lstParams["@Remark_VC"] = Remark;
            if (!string.IsNullOrEmpty(District))
            {
                lstParams["@Districts_FK"] = District;
            }
            else
            {
                lstParams["@Districts_FK"] = DBNull.Value;
            }

            if (!string.IsNullOrEmpty(Profession))
            {
                lstParams["@Profession_FK"] = Profession;
            }
            else
            {
                lstParams["@Profession_FK"] = DBNull.Value;
            }

            if (!string.IsNullOrEmpty(MartialStatus))
            {
                lstParams["@MartialStatus_FK"] = MartialStatus;
            }
            else
            {
                lstParams["@MartialStatus_FK"] = DBNull.Value;
            }


            if (!string.IsNullOrEmpty(Religion))
            {
                lstParams["@Religion_FK"] = Religion;
            }
            else
            {
                lstParams["@Religion_FK"] = DBNull.Value;
            }

            _conn.ExecProcedure("Patient_EXE", lstParams);

            LoadData();
        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearForm();

            pnlAdd.Visible = false;
            pnlGrid.Visible = false;
            pnlForm.Visible = true;

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Save();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            pnlAdd.Visible = true;
            pnlGrid.Visible = true;
            pnlForm.Visible = false;
        }

        protected void drpProvince_OnChange(object sender, EventArgs e)
        {
            LoadDataCity();
        }


        protected void drpCity_OnChange(object sender, EventArgs e)
        {
            LoadDataDistrict();
        }

        private void ClearForm()
        {
            this.txtName.Text = "";
            this.txtId.Text = "";
            this.txtAddress.Text = "";
            this.txtPOB.Text = "";
            this.txtDOB.Text = "";
            this.txtEmail.Text = "";
            this.txtPhone1.Text = "";
            this.txtPhone2.Text = "";
            this.txtRemark.Text = "";
            this.drpCity.Items.Clear();
            this.drpCity.Items.Add("Choose...");
            this.drpCity.Enabled = false;
            this.drpDistrict.Items.Clear();
            this.drpDistrict.Items.Add("Choose...");
            this.drpDistrict.Enabled = false;
            LoadDataProvince();
            LoadDataProfession();
            LoadDataMartialStatus();
            LoadDataReligion();

        }
    }


}