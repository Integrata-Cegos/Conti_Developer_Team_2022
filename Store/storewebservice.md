* Server URL
  * http://localhost:5000
* Basis-URL = Endpoint
  * http://localhost:5000/store
* Operations
  * GET
    * Parameters
      * Header-Parameter "category"
      * Path-Erweiterung: wird als item interpretiert
    * Result
      * text/plain
  * POST
    * Parameters
      * Header-Parameter "category"
      * Header-Parameter "item"
      * Header-Parameter "stock"