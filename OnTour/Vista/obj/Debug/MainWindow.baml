   M S B A M L   `   `   `  ����@  <Vista, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:VistaVista  5   	   H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=nullZ=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.MetroMahApps.Metro.Behaviours 5	   
   V;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls 5
   	       Vista.MainWindow   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Vista     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   
   N
behaviours=clr-namespace:MahApps.Metro.Behaviours;assembly=MahApps.Metro  5	   
   JControls;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro  5
   	     � Title$  OnTour��5   	   $	��650��6   $
��1180��6&   (  "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �   � � 
ResizeMode$ NoResize=�6M    � WindowStartupLocation$ CenterScreen=�6d      TitleCharacterCasing$ Normal=�6�    � Icon$ Imagenes/MapsR.png��6�   .��5      � ���	#FFAFF7F7$��0,0,-8,-18.333q�6"    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   �� 5      $��0* �6   �� 5      $��0* �6   .+�5   
   �� -   5         ��Name$ image��5      $
��Left=�6   $	��247��6:   $��350,246,0,0q�6G   $	��Top=�6\   $	��481��6t   $��Imagenes/logo_ontour1.png��6�   � 5   
   $
��Left=�6   $	��160��6*   $	��Top=�67   $
��1183��6O   ���	#FF9FC5F8$��4��6s   $��0,0,-0.333,0q�6�   .+�5      �� -   5        $ image1��5      $
��Left=�6$   $��61��6?   $��
437,81,0,0q�6K   $	��Top=�6_   $	��324��6w   $'��!Imagenes/TextArt_190611234427.png��6�   !  MahApps.Metro.Controls.Tile  5      -   5          Name$ Tile_Click_2��5      $��981,21,60,94q�62   $
��Auto��6H   $
��Auto��6V   ���	#FF9FC5F8.��5      � $��44��6   $	��135��6#   .+�5      �� -   5        $ image3��5      $
��Left=�6,   $��51��6G   $��
-8,-4,0,-3q�6S   $	��Top=�6g   $��62��6   $��Imagenes/Media-Start.png��6�   �� 5      -   5        	 ��Name$	 
label_Copy��5      $��Cerrar Sesión��60   $
��Left=�6H   $��34,9,0,0q�6c   $	��Top=�6u   $
��Bold"�6�   $��14.667(�6�   5      5      5        5   
   -   5        $ Tile_Click_3��5      ���	#FFAFF7F7$��907,259,102.667,254.333q�6`   $
��Auto��6�   $
��Auto��6�   .��5       � $	��146��6   $	��175��6    .+�5!      �� -   5        $ image4��5!      $
��Left=�6(   $��73��6C   $��	45,10,0,0q�6O   $	��Top=�6b   $��71��6z   $��Imagenes/reanudar.png��6�   
 J� RenderTransformOrigin$
 0.558,0.584&�6�   �� 5"      -   5        $	 label2��5"      $��Administrar Contrato��6(   $
��Left=�6G   $	��Top=�6b   $
��Bold"�6z   $��14.667(�6�   $��2,90,0,0q�6�   5#      5$      �� 5&   
   -	   5        $ image2��5&      $
��Left=�6    $��46��6;   $	��Top=�6G   $��57��6_   $!��Imagenes/Business-Man02.png��6j   $��
850,20,0,0q�6�   �� 5'   
   -
   5        $	 label��5'      $��Admin��6   $
��Left=�6/   $��
899,31,0,0q�6J   $	��Top=�6^   $
��Bold"�6v   $��14.667(�6�   $��29��6�   $��57��6�     5(   
   -   5        $ Tile_Click_4��5(      ���	#FFAFF7F7$��85,246,917.667,255.333q�6`   $
��Auto��6�   $
��Auto��6�   .��5)      � $	��115��6   $	��170��6    .+�5*      �� -   5        $ image5��5*      $
��Left=�6(   $��75��6C   $��45,4,0,0q�6O   $	��Top=�6a   $��72��6y   $��Imagenes/comunidad.png��6�   $
 0.558,0.584&�6�   �� 5+      -   5        $	 label1��5+      $��Administrar Cliente��6(   $
��Left=�6F   $	��Top=�6a   $
��Bold"�6y   $��14.667(�6�   $��8,84,0,0q�6�   $	��152��6�   5,      5-        5.   
   -   5        $ Tile_Aporte��5.      ���	#FFAFF7F7$��145,442,857.667,60.333q�6Y   $
��Auto��6y   $
��Auto��6�   .��5/      � $	��115��6   $	��170��6    .+�50      �� -   5        $ image6��50      $
��Left=�6(   $��75��6C   $��45,4,0,0q�6O   $	��Top=�6a   $��72��6y   $ ��Imagenes/pago-por-clic.png��6�   $
 0.558,0.584&�6�   �� 51      -   5        $	 label3��51      $��Registrar Aportes��6(   $
��Left=�6D   $	��Top=�6_   $
��Bold"�6w   $��14.667(�6�   $��8,84,0,0q�6�   52      53        54   
   -   5        $ Tile_correo��54      $��789,442,213.667,60.333q�6X   $
��Auto��6x   $
��Auto��6�   ��6-   Z� .��55      � $	��115��6   $	��170��6    .+�56      �� -   5        $ image7��56      $
��Left=�6(   $��75��6C   $��45,4,0,0q�6O   $	��Top=�6a   $��72��6y   $1��+Imagenes/mensajes-de-correo-electronico.png��6�   $
 0.558,0.584&�6�   �� 57      -   5        $	 label4��57      $��Enviar Correo��6(   $
��Left=�6@   $	��Top=�6[   $
��Bold"�6s   $��14.667(�6�   $��	24,84,0,0q�6�   58      59      5:      5;      