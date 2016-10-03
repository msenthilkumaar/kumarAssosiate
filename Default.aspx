<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContBody" Runat="Server">
    <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
        <WizardSteps>
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="center" colspan="2">
                                Sign Up for Your New Account</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security Question:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security Answer:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                <ContentTemplate>
                    <table>
                        <tr>
                            <td align="center">
                                Complete</td>
                        </tr>
                        <tr>
                            <td>
                                Your account has been successfully created.</td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="ContinueButton" runat="server" CausesValidation="False" 
                                    CommandName="Continue" Text="Continue" ValidationGroup="CreateUserWizard1" 
                                    onclick="ContinueButton_Click" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    <asp:Login ID="Login1" runat="server">
    </asp:Login>
 
   
    
    <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
    </asp:PasswordRecovery>
    <asp:ChangePassword ID="ChangePassword1" runat="server">
    </asp:ChangePassword><br />
       <asp:LoginName ID="LoginName1" runat="server" />
    <br /> <asp:LoginStatus ID="LoginStatus1" runat="server" /> <br /><br />
    <asp:LoginView ID="LoginView1" runat="server">
    </asp:LoginView>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContFooter" Runat="Server">
</asp:Content>

