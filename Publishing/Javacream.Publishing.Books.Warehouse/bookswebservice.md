* Server URL
  * http://localhost:5000
* Basis-URL = Endpoint
  * http://localhost:5000/book
* Operations
  * POST
    * Parameters
      * Pfad-Erweiterung title
      * Pfad-Erweiterung pages
      * Pfad-Erweiterung price
      * Body options
  * GET
    * Parameters
      * Pfad-Erweiterung isbn
  * GET
    * Parameters
      * Header-Parameter "title"
  * GET
    * Parameters
      * Header-Parameter "minPrice"
      * Header-Parameter "maxPrice"
  * DELETE
    * Parameters
      * Pfad-Erweiterung isbn
