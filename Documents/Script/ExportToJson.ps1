#Client export
mongoexport --uri="mongodb://localhost:27017/SkiService“ --collection=client --out=client.json

#Mittarbeiter export
mongoexport --uri="mongodb://localhost:27017/SkiService“ --collection=Mittarbeiter --out=mitarbeiter.json