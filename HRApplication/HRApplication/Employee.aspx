<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Employee.aspx.cs" Inherits="HRApplication.Employee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mt-3">
        <div class="col-md-12">
            <h3 class="text-center">Employee</h3>
            <hr />
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="row g-3">
                <div class="col-md-12">
                    <label for="xmlFile" class="form-label">Upload XML File</label>
                    <asp:FileUpload runat="server" class="form-control" ID="xmlFileUploder"></asp:FileUpload>
                    <asp:Button runat="server" Text="Upload" OnClick="OnUploadXmlFile"
                        class="btn btn-sm btn-outline-success mt-2">
                    </asp:Button>
                </div>
            </div>
        </div>
    </div>
    <div class="row mt-4">
        <div class="col-md-6">
            <div class="card">
                <div class="card-body">
                    <div class="row g-3">
                        <div class="col-md-12">
                            <label for="id" class="form-label">Id (Update/Delete/Search)</label>
                            <asp:TextBox runat="server" ID="id" type="text" class="form-control" placeholder="Employee Id"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="firstName" class="form-label">First Name</label>                            
                            <asp:TextBox runat="server" ID="firstName" type="text" class="form-control" placeholder="First Name"></asp:TextBox>
                        </div>
                        <div class="col-md-6">
                            <label for="lastName" class="form-label">Last Name</label>
                            <asp:TextBox runat="server" ID="lastName" type="text" class="form-control" placeholder="Last Name"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="division" class="form-label">Division</label>
                            <asp:TextBox runat="server" ID="division" type="text" class="form-control" placeholder="Division"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="building" class="form-label">Building</label>
                            <asp:TextBox runat="server" ID="building" type="text" class="form-control" placeholder="Building"></asp:TextBox>
                        </div>
                        <div class="col-4">
                            <label for="room" class="form-label">Room</label>
                            <asp:TextBox runat="server" ID="room" type="text" class="form-control" placeholder="Room"></asp:TextBox>
                        </div>
                        <div class="col-12">
                            <asp:Button runat="server" Text="Save" OnClick="OnSaveEmployee" 
                                class="btn btn-sm btn-outline-success">
                           </asp:Button> 
                            <asp:Button runat="server" Text="Update" OnClick="OnUpdateEmployee"
                                class="btn btn-sm btn-outline-success">
                            </asp:Button>
                            <asp:Button runat="server" Text="Delete" OnClick="OnDeleteEmployee"
                                class="btn btn-sm btn-outline-danger">
                            </asp:Button>
                            <asp:Button runat="server" Text="Search" OnClick="OnSearchEmployee"
                                class="btn btn-sm btn-outline-info">
                            </asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <asp:GridView runat="server" ID="employeeGridView" CssClass="custom-grid" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Id">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("Id") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="First Name">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("FirstName") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Last Name">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("LastName") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Division">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("Division") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Building">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("Building") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Room">
                        <ItemTemplate>
                            <div class="custom-cell">
                                <%# Eval("Room") %>
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>