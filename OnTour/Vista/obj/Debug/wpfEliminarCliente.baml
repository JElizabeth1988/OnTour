   M S B A M L   `   `   `  ����@  <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5   
   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5	   	       Vista.wpfEliminarCliente   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Vista     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5   
   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5	   	   6mah,http://metro.mahapps.com/winfx/xaml/controls  5
   	     � Title$  Eliminar Clientes��5   	   $��579.732��6#   $��677.838��64   (  "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6]    � WindowStartupLocation$ CenterScreen=�6t      TitleCharacterCasing$ Normal=�6�    � Icon$ Imagenes/MapsR.png��6�   .��5      � .+�5   
   � $
��Left=�6   $	��553��6*   $	��Top=�67   $	��686��6O   $��-2,-2,-390.667,-280.333q�6[   ���	#FFAFF7F7.+�5      �� -   5         ��Name$ btnCancelar��5      $��Salir��6*   $
��Left=�6:   $��510,482,0,0q�6U   $	��Top=�6j   $��74��6�   $��Normal"�6�    � Cursor$ Arrow��6�   )  #MahApps.Metro.Controls.ButtonHelper   PreserveTextCase . 	 J� RenderTransformOrigin$	 1.662,0.727&�6�      AccentedSquareButtonStyle#��[  6  &   System.Windows.Controls.DataGrid  5      -   5        
  Name$
 dgLista��5      $
��Left=�6(   $	��250��6C   $��
31,207,0,0q�6P   $	��Top=�6d   $	��622��6|   $
��Bold"�6�   �� 5      -   5         ��Name$ 	gbFiltrar��5      $��Filtrar Información��6*   $
��Left=�6G   $��
108,27,0,0q�6b   $	��Top=�6v   $	��152��6�   $	��476��6�   .��5      � $
��Left=�6   $	��110��62   $��10,4,0,0q�6?   $	��Top=�6Q   $	��426��6i   .+�5      �� -   5         ��Name$ label��5      $	��Rut��6+   $
��Left=�69   $	��Top=�6T   $��0,9,0,0q�6l   �� 5      -   5        $ label1��5      $��Comuna��6,   $
��Left=�6=   $��0,60,0,0q�6X   $	��Top=�6j   �� 5      -   5         ��Name$ txtFiltroRut��5      *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Ingrese Rut��65   $
��Left=�6_   $��23��6z   $��
112,10,0,0q�6�    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��137��6�   $��Normal"�6�      ClearTextButton . 6�   �� 5      -   5         ��Name$ cbCom��5      $
��Left=�6.   $��
111,60,0,0q�6I   $	��Top=�6]   $	��138��6u   $��26��6�   $��Normal"�6�   �� 5      -   5        $ btnFiltrarRut��5      $��Filtrar��64   $
��Left=�6F   $��
319,10,0,0q�6a   $	��Top=�6u   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  �� 5      -	   5        $ btnFiltrarTipo��5      $��Filtrar��65   $
��Left=�6G   $��
319,58,0,0q�6b   $	��Top=�6v   $��75��6�   $��Normal"�6�    . $	 1.662,0.727&�6�   #��[  6  5      5      �� 5      -
   5        $ btnRefrescar��5      $��	Refrescar��6+   $
��Left=�6?   $��108,482,0,0q�6Z   $	��Top=�6o   $��74��6�   $��Normal"�6�   $ Arrow��6�    . $	 1.662,0.727&�6�   #��[  6  �� 5      -   5        $ btnEliminar��5      $��Eliminar��6*   $
��Left=�6=   $��327,482,0,0q�6X   $	��Top=�6m   $��74��6�   $��Normal"�6�   $ Arrow��6�    . $	 1.662,0.727&�6�   #��[  6  5#      5%      5&      