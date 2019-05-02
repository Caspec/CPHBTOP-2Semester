const express = require('express')
const router = express.Router()
const getConnection = require('./mysqlconnection.js')
const bodyParser = require('body-parser')

router.use(bodyParser.urlencoded({ extended: 'false' }));
router.use(bodyParser.json())

// Gets all products
router.get("/products", (req, res) => {
    console.log("log --> Get all products: /products")
    const queryString = "SELECT product.*, category.* FROM product INNER JOIN category ON product.fk_category_id = category.category_id;"
    getConnection().query(queryString, (err, rows, fields) => {
        if (err) {
            console.log("log --> Failed to query: /products " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> SELECT: /products fetched successfully")
        res.json(rows)
    })
})

// Gets one product by ID
router.get("/product/:id", (req, res) => {
    console.log("log --> Fetching product id: " + req.params.id)
    const productId = req.params.id
    const queryString = "SELECT product.*, category.* FROM product INNER JOIN category ON product.fk_category_id = category.category_id WHERE product_id = ?;"
    getConnection().query(queryString, [productId], (err, rows, fields) => {
        if (err) {
            console.log("log --> Failed to query: /product/:id " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> SELECT: /product/:id fetched successfully")
        res.json(rows)
    })
})

// Gets images to product
router.get("/image/:id", (req, res) => {
    console.log("log --> Fetching image id: " + req.params.id)
    const fk_product_image_id = req.params.id
    const queryString = "SELECT image.* FROM image WHERE fk_product_image_id = ?"
    getConnection().query(queryString, [fk_product_image_id], (err, rows, fields) => {
        if (err) {
            console.log("log --> Failed to query: image id " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> SELECT: image id fetched successfully")
        res.json(rows)
    })
})

// Gets all images
router.get("/images", (req, res) => {
    console.log("log --> Get all images: /images")
    const queryString = "SELECT * FROM image"
    getConnection().query(queryString, (err, rows, fields) => {
        if (err) {
            console.log("log --> Failed to query: /image " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> SELECT: /image fetched successfully")
        res.json(rows)
    })
})

// Create a new product
router.post("/productadd", (req, res) => {
    const product_name = req.body.product_name.toString();
    const product_description = req.body.product_description.toString();
    const product_price = req.body.product_price.toString();
    const product_image = req.body.image_name.toString();
    const fk_category_id = req.body.fk_category_id.toString();
    const queryString = "INSERT INTO `product` (product_name, product_description, product_price, product_image, fk_category_id) VALUES (?, ?, ?, ?, ?);"
    getConnection().query(queryString, [product_name, product_description, product_price, product_image, fk_category_id], (err, results) => {
        if (err) {
            console.log("log --> Failed to query: /product_create " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> create new product: /product_create created successfully")
        res.end()
    })
})

// Edit a product
router.put("/productedit", (req, res) => {
    const product_id = req.body.product_id.toString();
    const product_name = req.body.product_name.toString();
    const product_description = req.body.product_description.toString();
    const product_price = req.body.product_price.toString();
    const product_image = req.body.product_image.toString();
    const fk_category_id = req.body.fk_category_id.toString();
    const queryString = "UPDATE product SET product_name = ?, product_description = ?, product_price = ?, product_image = ?, fk_category_id = ? WHERE product_id = ? ;"
    getConnection().query(queryString, [product_name, product_description, product_price, product_image, fk_category_id, product_id], (err, results) => {
        if (err) {
            console.log("log --> Failed to query: /product_edit " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> edit product: /product_edit edited successfully")
        res.end()
    })
})

// Delete a product
router.delete("/productdelete/:id", (req, res) => {
    const product_id = req.params.id;
    const queryString = "DELETE FROM product WHERE product_id = ? ;"
    getConnection().query(queryString, [product_id], (err, results) => {
        if (err) {
            console.log("log --> Failed to query: /product_delete " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> delete product: /product_delete delete successfully")
        res.end()
    })
})

module.exports = router