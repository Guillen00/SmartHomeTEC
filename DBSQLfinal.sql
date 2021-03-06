PGDMP         1                y            General    13.2    13.2 %    ?           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            ?           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            ?           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            ?           1262    16394    General    DATABASE     f   CREATE DATABASE "General" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Spanish_Mexico.1252';
    DROP DATABASE "General";
                postgres    false            ?            1259    16430    Aposento    TABLE     ?   CREATE TABLE public."Aposento" (
    "Correo" character varying(100) NOT NULL,
    "Aposento" character varying(40) NOT NULL
);
    DROP TABLE public."Aposento";
       public         heap    postgres    false            ?            1259    16420    Certificado de Garantia    TABLE       CREATE TABLE public."Certificado de Garantia" (
    "Fecha_de_Compra" date NOT NULL,
    "Fecha_Fin_Garantia" date NOT NULL,
    "Marca" character varying(40) NOT NULL,
    "Nombre_Dispositivo" character varying(70) NOT NULL,
    "Serie" integer NOT NULL
);
 -   DROP TABLE public."Certificado de Garantia";
       public         heap    postgres    false            ?            1259    16395    Dispositivo    TABLE     7  CREATE TABLE public."Dispositivo" (
    "Serie" integer NOT NULL,
    "Marca" character varying(40) NOT NULL,
    "Consumo_Electrico" integer NOT NULL,
    "Aposento" character varying(40) NOT NULL,
    "Nombre" character varying(70) NOT NULL,
    "Descripcion" character varying(300),
    "Tiempo_Garantia" integer NOT NULL,
    "Activo" boolean NOT NULL,
    "Historial_Duenos" character varying(300),
    "Distribuidor" character varying(300) NOT NULL,
    "AgregadoPor" character varying(300) NOT NULL,
    "Dueno" character varying(300),
    "Precio" integer
);
 !   DROP TABLE public."Dispositivo";
       public         heap    postgres    false            ?            1259    16405    Distribuidores    TABLE     ?   CREATE TABLE public."Distribuidores" (
    "Cedula_Juridica" integer NOT NULL,
    "NombreD" character varying(40) NOT NULL,
    "Continente" character varying(40) NOT NULL,
    "Pais" character varying(40) NOT NULL
);
 $   DROP TABLE public."Distribuidores";
       public         heap    postgres    false            ?            1259    16624    Factura    TABLE     ?   CREATE TABLE public."Factura" (
    "Factura" integer NOT NULL,
    "Serie" integer NOT NULL,
    "Fecha_de_Compra" date NOT NULL,
    "Nombre_Dispositivo" character varying(150) NOT NULL,
    "Precio" integer NOT NULL
);
    DROP TABLE public."Factura";
       public         heap    postgres    false            ?            1259    16400 	   Historial    TABLE     ?   CREATE TABLE public."Historial" (
    "Serie" integer NOT NULL,
    "Fecha" timestamp without time zone NOT NULL,
    "Tiempo_Encendido" integer NOT NULL
);
    DROP TABLE public."Historial";
       public         heap    postgres    false            ?            1259    16546    Pedidos    TABLE     5  CREATE TABLE public."Pedidos" (
    "Pedido" integer NOT NULL,
    "Fecha_y_Hora" date,
    "Nombre_de_Dispositivo" character varying(150) NOT NULL,
    "Marca" character varying(150) NOT NULL,
    "Serie" integer NOT NULL,
    "Monto_Total" integer NOT NULL,
    "Usuario" character varying(200) NOT NULL
);
    DROP TABLE public."Pedidos";
       public         heap    postgres    false            ?            1259    16410    Usuarios    TABLE     k  CREATE TABLE public."Usuarios" (
    "Nombre" character varying(40) NOT NULL,
    "Apellido" character varying(40) NOT NULL,
    "Correo" character varying(100) NOT NULL,
    "Contrasena" character varying(30) NOT NULL,
    "Direccion" character varying(300) NOT NULL,
    "Continente" character varying(40) NOT NULL,
    "Pais" character varying(40) NOT NULL
);
    DROP TABLE public."Usuarios";
       public         heap    postgres    false            ?          0    16430    Aposento 
   TABLE DATA           :   COPY public."Aposento" ("Correo", "Aposento") FROM stdin;
    public          postgres    false    205   ?1       ?          0    16420    Certificado de Garantia 
   TABLE DATA           ?   COPY public."Certificado de Garantia" ("Fecha_de_Compra", "Fecha_Fin_Garantia", "Marca", "Nombre_Dispositivo", "Serie") FROM stdin;
    public          postgres    false    204   Y2       ?          0    16395    Dispositivo 
   TABLE DATA           ?   COPY public."Dispositivo" ("Serie", "Marca", "Consumo_Electrico", "Aposento", "Nombre", "Descripcion", "Tiempo_Garantia", "Activo", "Historial_Duenos", "Distribuidor", "AgregadoPor", "Dueno", "Precio") FROM stdin;
    public          postgres    false    200   ?2       ?          0    16405    Distribuidores 
   TABLE DATA           ^   COPY public."Distribuidores" ("Cedula_Juridica", "NombreD", "Continente", "Pais") FROM stdin;
    public          postgres    false    202   c4       ?          0    16624    Factura 
   TABLE DATA           j   COPY public."Factura" ("Factura", "Serie", "Fecha_de_Compra", "Nombre_Dispositivo", "Precio") FROM stdin;
    public          postgres    false    207   ?4       ?          0    16400 	   Historial 
   TABLE DATA           K   COPY public."Historial" ("Serie", "Fecha", "Tiempo_Encendido") FROM stdin;
    public          postgres    false    201   45       ?          0    16546    Pedidos 
   TABLE DATA           ?   COPY public."Pedidos" ("Pedido", "Fecha_y_Hora", "Nombre_de_Dispositivo", "Marca", "Serie", "Monto_Total", "Usuario") FROM stdin;
    public          postgres    false    206   ?5       ?          0    16410    Usuarios 
   TABLE DATA           u   COPY public."Usuarios" ("Nombre", "Apellido", "Correo", "Contrasena", "Direccion", "Continente", "Pais") FROM stdin;
    public          postgres    false    203   ?5       J           2606    24841    Certificado de Garantia 1 
   CONSTRAINT     [   ALTER TABLE ONLY public."Certificado de Garantia"
    ADD CONSTRAINT "1" UNIQUE ("Serie");
 G   ALTER TABLE ONLY public."Certificado de Garantia" DROP CONSTRAINT "1";
       public            postgres    false    204            L           2606    16595 4   Certificado de Garantia Certificado de Garantia_pkey 
   CONSTRAINT     {   ALTER TABLE ONLY public."Certificado de Garantia"
    ADD CONSTRAINT "Certificado de Garantia_pkey" PRIMARY KEY ("Serie");
 b   ALTER TABLE ONLY public."Certificado de Garantia" DROP CONSTRAINT "Certificado de Garantia_pkey";
       public            postgres    false    204            @           2606    24839 !   Dispositivo Dispositivo_Serie_key 
   CONSTRAINT     c   ALTER TABLE ONLY public."Dispositivo"
    ADD CONSTRAINT "Dispositivo_Serie_key" UNIQUE ("Serie");
 O   ALTER TABLE ONLY public."Dispositivo" DROP CONSTRAINT "Dispositivo_Serie_key";
       public            postgres    false    200            B           2606    24887    Dispositivo Dispositivo_pkey 
   CONSTRAINT     c   ALTER TABLE ONLY public."Dispositivo"
    ADD CONSTRAINT "Dispositivo_pkey" PRIMARY KEY ("Serie");
 J   ALTER TABLE ONLY public."Dispositivo" DROP CONSTRAINT "Dispositivo_pkey";
       public            postgres    false    200            D           2606    24852 )   Distribuidores Distribuidores_NombreD_key 
   CONSTRAINT     m   ALTER TABLE ONLY public."Distribuidores"
    ADD CONSTRAINT "Distribuidores_NombreD_key" UNIQUE ("NombreD");
 W   ALTER TABLE ONLY public."Distribuidores" DROP CONSTRAINT "Distribuidores_NombreD_key";
       public            postgres    false    202            F           2606    16606 "   Distribuidores Distribuidores_pkey 
   CONSTRAINT     s   ALTER TABLE ONLY public."Distribuidores"
    ADD CONSTRAINT "Distribuidores_pkey" PRIMARY KEY ("Cedula_Juridica");
 P   ALTER TABLE ONLY public."Distribuidores" DROP CONSTRAINT "Distribuidores_pkey";
       public            postgres    false    202            P           2606    24859    Factura Factura_Serie_key 
   CONSTRAINT     [   ALTER TABLE ONLY public."Factura"
    ADD CONSTRAINT "Factura_Serie_key" UNIQUE ("Serie");
 G   ALTER TABLE ONLY public."Factura" DROP CONSTRAINT "Factura_Serie_key";
       public            postgres    false    207            R           2606    16628    Factura Factura_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public."Factura"
    ADD CONSTRAINT "Factura_pkey" PRIMARY KEY ("Serie");
 B   ALTER TABLE ONLY public."Factura" DROP CONSTRAINT "Factura_pkey";
       public            postgres    false    207            N           2606    16640    Pedidos Pedidos_pkey 
   CONSTRAINT     [   ALTER TABLE ONLY public."Pedidos"
    ADD CONSTRAINT "Pedidos_pkey" PRIMARY KEY ("Serie");
 B   ALTER TABLE ONLY public."Pedidos" DROP CONSTRAINT "Pedidos_pkey";
       public            postgres    false    206            H           2606    16560    Usuarios Usuarios_pkey 
   CONSTRAINT     ^   ALTER TABLE ONLY public."Usuarios"
    ADD CONSTRAINT "Usuarios_pkey" PRIMARY KEY ("Correo");
 D   ALTER TABLE ONLY public."Usuarios" DROP CONSTRAINT "Usuarios_pkey";
       public            postgres    false    203            U           2606    24842 :   Certificado de Garantia Certificado de Garantia_Serie_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Certificado de Garantia"
    ADD CONSTRAINT "Certificado de Garantia_Serie_fkey" FOREIGN KEY ("Serie") REFERENCES public."Dispositivo"("Serie") NOT VALID;
 h   ALTER TABLE ONLY public."Certificado de Garantia" DROP CONSTRAINT "Certificado de Garantia_Serie_fkey";
       public          postgres    false    204    200    2880            S           2606    24853 )   Dispositivo Dispositivo_Distribuidor_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Dispositivo"
    ADD CONSTRAINT "Dispositivo_Distribuidor_fkey" FOREIGN KEY ("Distribuidor") REFERENCES public."Distribuidores"("NombreD") NOT VALID;
 W   ALTER TABLE ONLY public."Dispositivo" DROP CONSTRAINT "Dispositivo_Distribuidor_fkey";
       public          postgres    false    2884    202    200            Y           2606    24860    Factura Factura_Serie_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Factura"
    ADD CONSTRAINT "Factura_Serie_fkey" FOREIGN KEY ("Serie") REFERENCES public."Dispositivo"("Serie") NOT VALID;
 H   ALTER TABLE ONLY public."Factura" DROP CONSTRAINT "Factura_Serie_fkey";
       public          postgres    false    200    207    2880            T           2606    24865    Historial Historial_Serie_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Historial"
    ADD CONSTRAINT "Historial_Serie_fkey" FOREIGN KEY ("Serie") REFERENCES public."Dispositivo"("Serie") NOT VALID;
 L   ALTER TABLE ONLY public."Historial" DROP CONSTRAINT "Historial_Serie_fkey";
       public          postgres    false    201    200    2880            X           2606    24875    Pedidos Pedidos_Serie_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Pedidos"
    ADD CONSTRAINT "Pedidos_Serie_fkey" FOREIGN KEY ("Serie") REFERENCES public."Dispositivo"("Serie") NOT VALID;
 H   ALTER TABLE ONLY public."Pedidos" DROP CONSTRAINT "Pedidos_Serie_fkey";
       public          postgres    false    2880    200    206            W           2606    24870    Pedidos Pedidos_Usuario_fkey    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Pedidos"
    ADD CONSTRAINT "Pedidos_Usuario_fkey" FOREIGN KEY ("Usuario") REFERENCES public."Usuarios"("Correo") NOT VALID;
 J   ALTER TABLE ONLY public."Pedidos" DROP CONSTRAINT "Pedidos_Usuario_fkey";
       public          postgres    false    2888    203    206            V           2606    24831 
   Aposento a    FK CONSTRAINT     ?   ALTER TABLE ONLY public."Aposento"
    ADD CONSTRAINT a FOREIGN KEY ("Correo") REFERENCES public."Usuarios"("Correo") NOT VALID;
 6   ALTER TABLE ONLY public."Aposento" DROP CONSTRAINT a;
       public          postgres    false    205    203    2888            ?   L   x??qH?M???K???L?/??,?/?????.?EX?81'E;X ? ?MC??"(??????,??)???? dqU      ?      x?e??
?@D??9?ݻ?bc?J?4?G 1????{???fg???S?n??g?	?8??2D}??)8=?o6??3?T?? "?芗b????O1?}ʫ??^?ֺ?&k????y?f????@D??)       ?   k  x????n?0???S?j???6v???\?6?R?	J??~)???S?????g??A)??v?j??
??RXH4-^???$B\?B[????%??sݢ?c?#,???ئi?&??m6j??Fhx?R7?IJn7?8????(?w??@')X?KTedx??le?%Zb[4????F[>????W???9??{?[???]?B(??UF??tU??H??$?ytE?:??昢P???3?YUfuPdKo??eWڵ???2?N??d??F)?gF閒?`?b?$ ???}QMd?*????&?*>H????w?1??D?y?\?[??6k?@????p0?5D曛0Ǝ??guc????z??$I~ ????      ?   g   x??44?tp?t,?L?t???K??44?t???tL+?L
?????9?
ҋQ?p:????q:概???M9?S??R?8]K??9=Ks2?b???? &P ?      ?   J   x?3?444?4200?50?5??t?I,?M?4?p%M?%?Rӊ2?S?S???\F?FFF?jr?? r1z\\\ ?      ?   =   x?344?4200?50?5?T00?#NS.C?P?P??ep?A???ʘ??Ce??b???? =?3      ?   Y   x?M?=
?0?9?KK?"?lz??%8!?????\????BR???j?X??V AD??Rm???AI????@????????ve??????      ?   ?   x?M???0C??W?*h?N[? &(??QPrW%?????Ŗ??? NJvu޳??? ??Q???i48?E?!#?]?^ӂ⚣y?$???9??j?A??&??uu???w=??'N??p#^\??G\`???@C!??y?Ƙ/A}<
     