<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Patient.aspx.cs" Inherits="Klinik.Patient" %>
<asp:Content ID="HeadContent" ContentPlaceHolderID="HeaderContent" runat="server">
    
    <script type="text/javascript">
        $(document).ready(function () {
            $(function () {
                $('#txtDOB').datepicker({
                    autoclose: true,
                    format: 'yyyy-mm-dd',
                    todayHighlight: true,
                    clearBtn: true,
                    orientation: 'bottom'
                });
                //$('#uxDateTimeLocalTextbox').datetimepicker();
            });
        });
    </script>
</asp:Content>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <h2>Patient</h2>
    <asp:Panel ID="pnlAdd" runat="server">
        <asp:Button ID="btnAdd" runat="server" CssClass="btn btn-success" OnClick="btnAdd_Click" Text="Add" />
    </asp:Panel>
    <br />
    <asp:Panel ID="pnlGrid" runat="server">
        <asp:GridView ID="dgvData" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover"
            CellPadding="5" CellSpacing="0" AllowPaging="true" PageSize="20" PagerSettings-Visible="false" AllowCustomPaging="false"
            UseAccessibleHeader="true" Width="100%" OnRowCommand="dgvData_RowCommand">
            <Columns>
                <asp:TemplateField HeaderText="Patient" HeaderStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblPatientPK" runat="server" Text='<%# Eval("Patient_PK")%>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" ItemStyle-VerticalAlign="Top" ItemStyle-HorizontalAlign="Center">
                    <HeaderTemplate>
                        #
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:Button ID="imbDetail" runat="server" CssClass="Button" CommandName="Detail" CommandArgument="<%# Container.DataItemIndex %>" Text="Edit" />
                        <%--<asp:ImageButton ID="imbDetail" runat="server" ImageUrl="~/Images/table.gif" CommandName="Detail" CommandArgument="<%# Container.DataItemIndex %>" />--%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Code" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%# Eval("Code_VC")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Name" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%# Eval("Name_VC")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%# Eval("Email_VC")%>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone" HeaderStyle-HorizontalAlign="Left" ItemStyle-HorizontalAlign="Left" ItemStyle-VerticalAlign="Top">
                    <ItemTemplate>
                        <%# Eval("Phone1_VC")%>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnlForm" runat="server">
        <div class="row col-md-8">
            <asp:HiddenField ID="hidPatientPK" runat="server" />
            <div class="col-md-6">
              <label for="txtName" class="form-label">Name</label>
                <asp:TextBox id="txtName" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtName" placeholder="" value="" required>--%>
            </div>
            
            <div class="col-md-6">
              <label for="txtId" class="form-label">Id</label>
                <asp:TextBox id="txtId" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtId" placeholder="" value="" required>--%>
            </div>

            <div class="col-md-6">
              <label for="txtPOB" class="form-label">Place of Birth</label>
                <asp:TextBox id="txtPOB" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtPOB" placeholder="" value="" required>--%>
            </div>
            
            <div class="col-md-6">
              <label for="txtDOB" class="form-label">Date of Birth</label>
                <asp:TextBox id="txtDOB" runat="server" CssClass="form-control" ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtDOB" placeholder="" value="" required>--%>
            </div>

            
            <div class="col-md-12">
              <label for="txtAddress" class="form-label">Address</label>
                <asp:TextBox id="txtAddress" runat="server" TextMode="MultiLine" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtAddress" required>--%>
            </div>
            
            <div class="col-md-4">
              <label for="drpProvince" class="form-label">Province</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpProvince" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="drpProvince_OnChange"  ClientIDMode="Static"></asp:DropDownList>
              <%--<select class="custom-select d-block w-100" id="drpProvince" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>
            
            <div class="col-md-4">
              <label for="drpCity" class="form-label">City</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpCity"  AutoPostBack="true" OnSelectedIndexChanged="drpCity_OnChange"  ClientIDMode="Static" runat="server"></asp:DropDownList>
              <%--<select class="custom-select d-block w-100" id="drpCity" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>
            
            <div class="col-md-4">
              <label for="drpDistrict" class="form-label">District</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpDistrict" runat="server" ClientIDMode="Static"></asp:DropDownList>
              <%--<select class="custom-select d-block w-100" id="drpDistrict" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>

            
            
            <div class="col-md-12">
              <label for="drpProfession" class="form-label">Profession</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpProfession" runat="server"  ClientIDMode="Static"></asp:DropDownList>
             <%-- <select class="custom-select d-block w-100" id="drpProfession" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>

            
            <div class="col-md-12">
              <label for="drpMartialStatus" class="form-label">Martial Status</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpMartialStatus" runat="server"  ClientIDMode="Static"></asp:DropDownList>
             <%-- <select class="custom-select d-block w-100t" id="drpMartialStatus" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>
            
            <div class="col-md-12">
              <label for="drpReligion" class="form-label">Religion</label>
                <asp:DropDownList CssClass="custom-select d-block w-100" ID="drpReligion" runat="server"  ClientIDMode="Static"></asp:DropDownList>
              <%--<select class="custom-select d-block w-100" id="drpReligion" required>
                <option value="">Choose...</option>
                <option>United States</option>
              </select>--%>
            </div>


            <div class="col-md-12">
              <label for="email" class="form-label">Email</label>
                <asp:TextBox id="txtEmail" runat="server" TextMode="Email" CssClass="form-control"  ClientIDMode="Static"/>
             <%-- <input type="email" class="form-control" id="email" placeholder="you@example.com" required>--%>
            </div>
            
            <div class="col-md-6">
              <label for="txtPhone1" class="form-label">Phone 1</label>
                <asp:TextBox id="txtPhone1" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtPhone1" placeholder="" required>--%>
            </div>
            
            <div class="col-md-6">
              <label for="txtPhone2" class="form-label">Phone 2 <span class="text-muted">(Optional)</span></label>
                <asp:TextBox id="txtPhone2" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtPhone2" placeholder="" >--%>
            </div>


            <div class="col-md-12">
              <label for="txtRemark" class="form-label">Remark <span class="text-muted">(Optional)</span></label>
                <asp:TextBox id="txtRemark" runat="server" CssClass="form-control"  ClientIDMode="Static"/>
              <%--<input type="text" class="form-control" id="txtRemark" placeholder="Apartment or suite">--%>
            </div>

          </div>

          <hr class="my-4">

            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-lg" Text="Submit" OnClick="btnSubmit_Click" ClientIDMode="Static"/>
            <asp:Button ID="btnBack" runat="server" CssClass="btn btn-default btn-lg" OnClick="btnCancel_Click" Text="Back" ClientIDMode="Static"/>
    </asp:Panel>
        
</asp:Content>