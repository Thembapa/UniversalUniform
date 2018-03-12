<%@ Page Title="" Language="C#"  MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SignIn.aspx.cs" Inherits="UniversalUniform.SignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="heading">
                <h1>Signin</h1>
                <span>Log into your acount</span>
              </div>
    <form runat="server">
        <table style="width:100%">
                <tr>
                      <td style="width:40%"></td>
                    <td style="text-align:right ;color:orange; background-color:white">
                        <h4><em>Username</em></h4>
                    </td>

                     <td style="text-align:left ; background-color:white">
                         <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                    </td>
                    <td style=" width:40%">
                        <asp:Label ID="lbError" runat="server" ForeColor="Red" Font-Size="Large" Font-Bold="false"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right ;color:orange; background-color:white">
                        <h4><em>Passoword</em></h4>
                    </td>
                     <td style="text-align:left; background-color:white">
                        <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"  ></asp:TextBox>
                         
                    </td>
                    <td style=" width:40%"></td>
                </tr>
                <tr>
                    <td></td>
                    <td style="text-align:right ;color:orange; background-color:white">
                        <h4><asp:Label ID="lbPassword2" Text=" Confirm Password" runat="server" Visible="false"></asp:Label> </h4>
                    </td>
                     <td style="text-align:left; background-color:white">
                        <asp:TextBox ID="txtPassword2" TextMode="Password" runat="server"  ></asp:TextBox>                         
                    </td>
                    <td style=" width:40%"></td>
                </tr>
                
                 <tr>
                     <td>

                </td>
                    <td style="text-align:center; background-color:white" colspan="2" >
                       <div>
                         <asp:Button ID="cbSignIn" runat="server" Text="SignIn" CssClass="cmdButton" OnClick="cbSignIn_Click" />
                         <asp:Button ID="cmdSinUp" runat="server" Text="SignUp" CssClass="cmdButton" OnClick="cmdSinUp_Click" />
                        </div>
                    </td>
                    <td>

                </td>

                </tr>
                      <tr>
                          <td style="height:350px" colspan="4">

                          </td>
                      </tr>
            
            </table>
    </form>
</asp:Content>
