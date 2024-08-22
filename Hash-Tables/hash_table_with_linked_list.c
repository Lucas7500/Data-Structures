#include <stdio.h>
#include <limits.h>
#include <stdlib.h>
#include <string.h>

#define TABLE_SIZE 100000

typedef struct entry_t
{
    char *key;
    char *value;
    struct entry_t *next;
} entry_t;

typedef struct 
{
    entry_t **entries;
} ht_t;

unsigned int hash(const char *);
entry_t *ht_pair(const char *, const char *);
ht_t *ht_create(void);
char *ht_get(ht_t *, const char *);
void ht_set(ht_t *, const char *, const char *);
void ht_dump(ht_t *);

unsigned int hash(const char *key)
{
    unsigned long int value = 0;
    unsigned int key_len = strlen(key);

    for (int i = 0; i < key_len; ++i)
    {
        value = value * 37 + key[i];
    }

    return (value % TABLE_SIZE);
}

entry_t *ht_pair(const char *key, const char *value)
{
    entry_t *entry = (entry_t *)malloc(sizeof(entry_t));
    
    entry->key = (char *)malloc(strlen(key) + 1);
    entry->value = (char *)malloc(strlen(value) + 1);

    strcpy(entry->key, key);
    strcpy(entry->value, value);

    entry->next = NULL;

    return entry;
}

ht_t *ht_create(void) 
{
    ht_t *hashtable = (ht_t *)malloc(sizeof(ht_t));

    hashtable->entries = (entry_t **)malloc(sizeof(entry_t *) * TABLE_SIZE);

    for (int i = 0; i < TABLE_SIZE; i++)
    {
        hashtable->entries[i] = NULL;
    }

    return hashtable;
}

char *ht_get(ht_t *hashtable, const char *key)
{
    unsigned int slot = hash(key);
    entry_t *entry = hashtable->entries[slot];

    while(entry != NULL)
    {
        if (strcmp(entry->key, key) == 0)
        {
            return entry->value;
        }

        entry = entry->next;
    }

    return NULL;
}

void ht_set(ht_t *hashtable, const char *key, const char *value) 
{
    unsigned int bucket = hash(key);

    entry_t *entry = hashtable->entries[bucket];

    if (entry == NULL)
    {
        hashtable->entries[bucket] = ht_pair(key, value);
        return;
    }

    entry_t *prev;

    while (entry != NULL)
    {
        if (strcmp(entry->key, key) == 0)
        {
            free(entry->value);
            entry->value = (char *)malloc(strlen(value) + 1);
            strcpy(entry->value, value);
            return;
        }

        prev = entry;
        entry = entry->next;
    }

    prev->next = ht_pair(key, value);
}

void ht_dump(ht_t *hashtable)
{
    for (int i = 0; i < TABLE_SIZE; i++)
    {
        entry_t *entry = hashtable->entries[i];

        if (entry == NULL)
        {
            continue;
        }

        printf("slot[%4d]: ", i);

        while(1)
        {
            printf("%s=%s ", entry->key, entry->value);

            if (entry->next == NULL)
            {
                break;
            }

            entry = entry->next;
        }

        printf("\n");
    }
}

int main(void)
{
    ht_t *ht = ht_create();

    ht_set(ht, "name1", "em");
    ht_set(ht, "name2", "russian");
    ht_set(ht, "name3", "pizza");
    ht_set(ht, "name4", "doge");
    ht_set(ht, "name5", "pyro");
    ht_set(ht, "name6", "joost");
    ht_set(ht, "name7", "kalix");

    ht_dump(ht);

    return 0;
}