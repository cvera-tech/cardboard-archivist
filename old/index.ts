import express, { Express, Request, Response } from 'express';
import dotenv from 'dotenv';
import fs from 'fs/promises';
import path from 'path';

dotenv.config();

const app: Express = express();
const port = process.env.PORT;

app.get('/', async (req: Request, res: Response) => {
    try {
        const fileData = await fs.readFile(path.join(__dirname, '..', '..', 'data', 'seed', 'Font\ of\ Fortunes.json',), {encoding: "utf-8"});
        res.send(fileData);
    } catch (error) {
        res.send('Oops something bad happened in the back end!');
    }
});

app.listen(port, () => {
    console.log(`[server] Server is running on http://localhost:${port}`);
});