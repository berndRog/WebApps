using Microsoft.AspNetCore.Components;
namespace WebApp.Components.Pages;

public partial class StopWatch : ComponentBase {
   
   private bool _isRunning = false;
   private TimeSpan _elapsedTime = TimeSpan.Zero;
   private DateTime _startTime;
   private string _formattedTime => _elapsedTime.ToString(@"hh\:mm\:ss\.ff");
   private CancellationTokenSource? _cts;

   private async Task StartStopwatch() {
      if (_isRunning) return;
      _isRunning = true;
      _startTime = DateTime.UtcNow - _elapsedTime;
      _cts = new CancellationTokenSource();

      while (!_cts.Token.IsCancellationRequested) {
         _elapsedTime = DateTime.UtcNow - _startTime;
         await InvokeAsync(StateHasChanged);
         await Task.Delay(10, _cts.Token); // refresh all 10ms
      }
   }

   private void StopStopwatch() {
      if (!_isRunning) return;
      _isRunning = false;
      _cts?.Cancel();
   }

   private void ResetStopwatch() {
      _isRunning = false;
      _cts?.Cancel();
      _elapsedTime = TimeSpan.Zero;
   }
}