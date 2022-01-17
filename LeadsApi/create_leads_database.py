#!/usr/bin/env python3

"""
Autor: Halil Ibrahim Özcan
Beschreibung:
    Erstellt eine neue SQLite-Datenbank und füllt diese
    mit Test-Daten
"""

import sqlite3
import random


Id = [i for i in range(10)]

names = ['Mayra Ewing',
            'Emery Roach',
            'Ryan Galloway',
            'Jamir Oneill',
            'Carl Bailey',
            'Ashlynn Scott',
            'Ryland Yoder',
            'Lucian Barajas',
            'Dania Lopez',
            'Wesley Key']

zip_codes = ["30223",
            "22003",
            "92111",
            "99504",
            "14580",
            "10956",
            "10512",
            "08817",
            "20815",
            "23059"]

random_probs = [round(random.uniform(0, 1), 2) for i in  range(10)]

zipped_data = list(zip(Id, names, zip_codes, random_probs))

def main():
    try:
        connection = sqlite3.connect("LeadsDatabase.db")
        create_db_sql = '''CREATE TABLE IF NOT EXISTS
                            Lead (Id Integer,
                                   Name TEXT,
                                   ZipCode TEXT,
                                   ConversionProb REAL);'''
        connection.execute(create_db_sql)
        insert_data_sql = "INSERT INTO Lead VALUES(?, ?, ?, ?)"
        connection.executemany(insert_data_sql, zipped_data)
           
    except ConnectionError as e:
        print(e)

    finally:
        if connection:
            connection.commit()
            connection.close()


if __name__ == '__main__':
    main()
