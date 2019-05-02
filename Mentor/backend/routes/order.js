const express = require('express')
const router = express.Router()
const getConnection = require('./mysqlconnection.js')
const bodyParser = require('body-parser')

router.use(bodyParser.urlencoded({ extended: 'false' }));
router.use(bodyParser.json())

// Gets all orders
router.get("/orders", (req, res) => {
    console.log("log --> Get all orders: /orders")
    const queryString = "SELECT * FROM orders"
    getConnection().query(queryString, (err, rows, fields) => {

        if (err) {
            console.log("log --> Failed to query: /orders " + err)
            res.sendStatus(500)
            return
        }

        console.log("log --> SELECT: /orders fetched successfully")
        res.json(rows)
    })
})

// Gets one order by ID
router.get("/orders/:id", (req, res) => {
    console.log("log --> Fetching orders id: " + req.params.id)
    const ordersId = req.params.id
    const queryString = "SELECT * FROM orders WHERE orders_id = ?"
    getConnection().query(queryString, [ordersId], (err, rows, fields) => {
        if (err) {
            console.log("log --> Failed to query: /orders/:id " + err)
            res.sendStatus(500)
            return
        }
        console.log("log --> SELECT: /orders/:id fetched successfully")
        res.json(rows)
    })
})

module.exports = router