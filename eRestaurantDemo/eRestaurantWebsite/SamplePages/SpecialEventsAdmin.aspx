<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="SpecialEventsAdmin.aspx.cs" Inherits="SpecialEventsAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" Runat="Server">
    <h1>Special Events Administration</h1>
    <table align="center" style="width: 80%">
        <tr>
            <td align="right" style="width:50%">Select an Event:&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="SpecialEventList" runat="server" width="200px" DataSourceID="ODSSpecialEvents" DataTextField="Description" DataValueField="EventCode" AppendDataBoundItems="true">
                    <asp:ListItem Value="0">Select an Event</asp:ListItem>
                </asp:DropDownList>&nbsp;&nbsp;
                <asp:LinkButton ID="FetchReservations" runat="server">Fetch Reservations</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td colspan="2">&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="ReservationListGV" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="ODSReservations">
                    <AlternatingRowStyle BackColor="#999999" />
                    <Columns>
                        <asp:BoundField DataField="CustomerName" HeaderText="Customer Name" SortExpression="CustomerName" />
                        <asp:BoundField DataField="ReservationDate" HeaderText="Reservation Date" SortExpression="ReservationDate" />
                        <asp:BoundField DataField="NumberInParty" HeaderText="Number In Party" SortExpression="NumberInParty" />
                        <asp:BoundField DataField="ContactPhone" HeaderText="Contact Phone" SortExpression="ContactPhone" />
                        <asp:BoundField DataField="ReservationStatus" HeaderText="Reservation Status" SortExpression="ReservationStatus" />
                        <asp:BoundField DataField="EventCode" HeaderText="Event Code" SortExpression="EventCode" />
                    </Columns>
                    <EmptyDataTemplate>
                        No data to display
                    </EmptyDataTemplate>
                    <RowStyle BackColor="#CCCCCC" />
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td align ="center">
                <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AllowPaging="True" DataSourceID="ODSReservations">
                    <EmptyDataTemplate>
                        No data found
                    </EmptyDataTemplate>
                </asp:DetailsView>
            </td>
            
        </tr>
        <tr>
            <td style="height: 22px"></td>
            <td style="height: 22px"></td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="ODSSpecialEvents" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="SpecialEvent_List" TypeName="eResturauntSystem.BLL.AdminController"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="ODSReservations" runat="server" OldValuesParameterFormatString="original_{0}" SelectMethod="GetReservationsByEventCode" TypeName="eResturauntSystem.BLL.AdminController">
        <SelectParameters>
            <asp:ControlParameter ControlID="SpecialEventList" Name="eventcode" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>

