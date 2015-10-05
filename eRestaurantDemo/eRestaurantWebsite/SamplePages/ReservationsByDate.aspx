<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="ReservationsByDate.aspx.cs" Inherits="SamplePages_ReservationsByDate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Reservations By Date</h1>
    <table style="width: 70%">
        <tr>
            <td align="right">Enter reservation date(mm/dd/yyyy):</td>
            <td>
                <asp:TextBox ID="ReservationDateArg" runat="server" text="01/01/2000"></asp:TextBox>
                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2"><div class="row col-md-12">
                   
                            <asp:Repeater ID="EventReservations" runat="server" DataSourceID="ODSEventReservations">
                                <ItemTemplate>
                                    <h3><%# Eval("Description") %></h3>
                                        <asp:Repeater ID="ReservationsList" runat="server" DataSource=<%# Eval("Reservations") %>>
                                            <ItemTemplate>
                                                <h5>
                                                    <%# Eval("CustomerName") %>
                                                    <%# Eval("ContactPhone") %>
                                                </h5>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                </ItemTemplate>
                            </asp:Repeater>
                
                            </div></td>

        </tr>
    </table>
    <asp:ObjectDataSource ID="ODSEventReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByDate" TypeName="eResturauntSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="ReservationDateArg" Name="reservationdate" PropertyName="Text" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>


