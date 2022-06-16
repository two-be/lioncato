#nullable disable

using Lioncato.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using Radzen;

namespace Lioncato.Pages;

public class AbstractComponentBase : ComponentBase
{
    [Inject]
    protected IDbContextFactory<AppDbContext> DbFactory { get; set; }
    [Inject]
    protected DialogService Dialog { get; set; }
    [Inject]
    protected ProtectedLocalStorage LocalStorage { get; set; }
    [Inject]
    protected IJSRuntime Js { get; set; }
    [Inject]
    protected NavigationManager Navigation { get; set; }
    [Inject]
    protected AppService Service { get; set; }

    protected bool IsLoading = false;
    protected bool IsSignedIn => !string.IsNullOrEmpty(User.Id);
    protected string Keyword = string.Empty;
    protected UserInfo User = new UserInfo(string.Empty);

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (string.IsNullOrEmpty(User.Id))
        {
            User = await Service.GetUserAsync(LocalStorage);
            StateHasChanged();
        }
        await base.OnAfterRenderAsync(firstRender);
    }

    protected async Task AlertAsync(object message)
    {
        await Js.InvokeVoidAsync("alert", message);
    }

    protected async Task<bool> ConfirmAsync()
    {
        return await Js.InvokeAsync<bool>("confirm", "Are you sure?");
    }

    protected async Task ErrorAsync(Exception ex)
    {
        if (ex.InnerException is not null)
        {
            await AlertAsync(ex.InnerException.Message);
        }
        else
        {
            await AlertAsync(ex.Message);
        }
        SetLoading(false);
    }

    protected void SetLoading(bool value)
    {
        IsLoading = value;
        StateHasChanged();
    }
}