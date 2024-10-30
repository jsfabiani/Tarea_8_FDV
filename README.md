# Tarea_8_FDV

#### Tarea: Aplicar un fondo con scroll a tu escena utilizando una cámara fija, con dos fondos que se desplaza a la derecha.

Usamos el script Background Scrolling Fixed Camera

Recuperamos una referencia al collider2D, y creamos una variable con su tamaño.
```
void Start()
{
    backgroundCollider = this.GetComponent<Collider2D>();
    backgroundWidth = backgroundCollider.bounds.size.x;   
}
```

En el Update, la movemos en el eje x. Cuando la posición pasa a ser el ancho en negativo, trasladamos el fondo dos anchos a su derecha.

```
void Update()
{
    transform.Translate(- scrollSpeed*Time.deltaTime, 0, 0);

    if (transform.position.x <= - 1 * backgroundWidth)
    {
        
        transform.position = new Vector3 (backgroundWidth , transform.position.y, transform.position.z);
        
    }
}
```

![](https://github.com/jsfabiani/Tarea_8_FDV/blob/main/gifs/FDV_8_gif_1.gif)


#### Tarea: Aplicar un fondo con scroll a tu escena utilizando una cámara móvil y dos fondos estáticos, transladándolos cuando avance la cámara.

Usamos el script BackgroundScrollingMovingCamera.

Igual que antes, creamos variables para el collider y el ancho. También creamos una referencia _camera al GameObject de la cámara. La operación es muy similar a la anterior, pero esta vez comparamos la posición del fondo con la de la cámara.

```
void Update()
{
    if (transform.position.x + backgroundWidth < _camera.transform.position.x) {

        transform.position += 2 * backgroundWidth * Vector3.right;
    }
}
```

![](https://github.com/jsfabiani/Tarea_8_FDV/blob/main/gifs/FDV_8_gif_2.gif)


#### Tarea: Aplicar un fondo a tu escena aplicando la técnica del desplazamiento de textura.

Usamos el script BackgroundTextureOffset.

Creamos una variable de rend, que asignamos al componente Renderer. Creamos un float para el offset, que ponemos a 0. En el Update, aumentamos el offset y actualizamos la textura. Tenemos que poner la textura con Wrap Repeat para que funcione.

```
void Update()
{
    offset += Time.deltaTime * scrollSpeed;
    rend.material.SetTextureOffset("_MainTex", new Vector2 (offset, 0));
}
```

![](https://github.com/jsfabiani/Tarea_8_FDV/blob/main/gifs/FDV_8_gif_3.gif)


#### Tarea: Aplicar efecto parallax usando la técnica de scroll en la que se mueve continuamente la posición del fondo.

Empezamos creando un array de GameObjects que llamamos LayersGameObject, donde haremos referencia a los fondos. Tenemos que ordenar de más lejano a más cercano en la lista, y tenemos que poner juntos el fondo y el de repuesto en posiciones pares, de esta forma:
(screenshot)

En Update, hacemos un bucle para recorrer los GameObjects del array. Para cada uno, realizamos la misma operación que hicimos en la primera tarea. Dividimos la velocidad de desplazamiento por (1 + Mathf.Ceil(i/2)), para ir modificando la velocidad a la que se desplazan los fondos dos a dos.
```
void Update()
{
    int i = 0;
    foreach (GameObject layer in LayersGameObject)
    {
        layer.transform.Translate(- scrollSpeed*Time.deltaTime/(1+Mathf.Ceil(i/2)), 0f, 0f);
        float backgroundWidth = layer.GetComponent<Collider2D>().bounds.size.x;

        if (layer.transform.position.x <= - 1 * backgroundWidth)
        {               
        layer.transform.position = new Vector3 (backgroundWidth , layer.transform.position.y, 0f);
        }
        i++;
    } 
}
```
![](https://github.com/jsfabiani/Tarea_8_FDV/blob/main/gifs/FDV_8_gif_4.gif)


#### Tarea: Aplicar efecto parallax actualizando el offset de la textura.
