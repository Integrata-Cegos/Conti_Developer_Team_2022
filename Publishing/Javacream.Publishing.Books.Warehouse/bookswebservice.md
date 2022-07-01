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
        * application/json
    * Result
      * text/plain
  * GET
    * Parameters
      * Pfad-Erweiterung isbn
    * Result
      * application/json
  * GET
    * Parameters
      * Header-Parameter "title"
    * Result
      * application/json
  * GET
    * Parameters
      * Header-Parameter "minPrice"
      * Header-Parameter "maxPrice"
    * Result
      * application/json
  * DELETE
    * Parameters
      * Pfad-Erweiterung isbn
* Types
  * Book
    * isbn Isbn
    * title string
    * price double
    * pages integer
    * available boolean
  * Isbn
    * part1
    * part2
    * part3
    * part4
