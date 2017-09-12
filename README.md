This is a beginners guid to implement the IDisposable Interface inorder to free managed and unmanaged resources.

What is an managed resource? 
Ans: If you found it in the Microsoft .NET Framework: it's managed.

What is an unmanaged resource? 
Anything you've used or Invoke from outside of the .NET Framwork is unmanaged – and you're now responsible for cleaning it up.
The object that you've created needs to expose some method, that the outside world can call, in order to clean up unmanaged resources.
